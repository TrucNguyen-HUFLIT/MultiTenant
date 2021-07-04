using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Application.Exceptions;
using MultiTenant.Application.Models.MultiTenants.Account;
using MultiTenant.Data.Contexts;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenant.Application.Services.MultiTenants.User
{
    public class UserService : IUserService
    {
        private readonly MultiTenantContext _context;
        private readonly IWebHostEnvironment hostEnvironment;

        public UserService(MultiTenantContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task<bool> ChangeImageAsync(ChangeImage changeImage)
        {
            string wwwRootPath = hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(changeImage.UploadAvt.FileName);
            string extension = Path.GetExtension(changeImage.UploadAvt.FileName);
            fileName += extension;
            string path = Path.Combine(wwwRootPath + "/img/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await changeImage.UploadAvt.CopyToAsync(fileStream);
            }
            changeImage.Avatar = "/img/" + fileName;

            var model = await _context.Accounts
                .Where(x => x.AccId == changeImage.AccId)
                .FirstOrDefaultAsync();

            model.Avatar = changeImage.Avatar;

            _context.Update(model);
            await _context.SaveChangesAsync();
            return true;

        }

        public Task CreateAsync(AccountCreate accountCreate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditAsync(AccountEdit accountEdit)
        {
            var model = await _context.Accounts
                  .Where(x => x.AccId == accountEdit.AccId)
                  .FirstOrDefaultAsync();
            var email = await _context.Accounts.Select(x => x.Email).ToListAsync();
            foreach(var e in email)
            {
                if (e == accountEdit.Email)
                {
                    throw new SameEmailException(model.Email);
                }
            }
            model.Name = accountEdit.Name;
            model.TenantId = accountEdit.TenantId;
            model.Email = accountEdit.Email;
            _context.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AccountEdit> GetAccountEditByIdAsync(int id)
        {
            var model = await _context.Accounts
                .Where(x => x.AccId == id)
                .Select(x => new { x.AccId, x.Avatar, x.Email, x.TenantId, x.Role ,x.Name})
                .FirstOrDefaultAsync();
            if(model!=null)
            {
                var accountEdit = new AccountEdit
                {

                    AccId = model.AccId,
                    Name=model.Name,
                    Email = model.Email,
                    Avatar = model.Avatar,
                    Role = model.Role,
                    TenantId = model.TenantId,
                };
                return accountEdit;
            }
            return null;
        }

        public List<Tenant> GetListTenant()
        {
            var model = _context.Tenants.ToList();
            return model;
        }


        public async Task<PagingList<Account>> GetListUsersAsync(string filter, int page, string sortEx = "AccId")
        {

            var qry = _context.Accounts.AsNoTracking().OrderBy(p => p.Email).AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                qry = qry.Where(p => p.Email.StartsWith(filter));
            }

            var model = await PagingList.CreateAsync(qry, 10, page, sortEx, "AccId");

            model.RouteValue = new RouteValueDictionary {
            { "filter", filter}
            };

            return model;
        }
    }
}
