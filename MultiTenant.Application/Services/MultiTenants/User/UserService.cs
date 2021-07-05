using IdentityServer4.Test;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Application.Exceptions;
using MultiTenant.Application.Models.MultiTenants.Account;
using MultiTenant.Application.Services.MultiTenants.User;
using MultiTenant.Data.Contexts;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MultiTenant.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly MultiTenantContext _context;
        private readonly IWebHostEnvironment hostEnvironment;
       // private readonly TenantContext _tenantContext;

        public UserService(MultiTenantContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.hostEnvironment = hostEnvironment;
            //_tenantContext = tenantContext;           
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

        public async Task CreateAsync(AccountCreate accountCreate)
        {
            var username = _context.Accounts.Where(x => x.UserName == accountCreate.UserName).Select(x=>x.UserName).FirstOrDefault();
            if(username==null)
            {
                var model = new Account
                {
                    Name = accountCreate.Name,
                    UserName = accountCreate.UserName,
                    Password = accountCreate.Password,
                    Role = accountCreate.Role,
                    Email = accountCreate.Email,
                    TenantId = accountCreate.TenantId,
                    Avatar = accountCreate.Avatar
                };
                string wwwRootPath = hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(accountCreate.UploadAvt.FileName);
                string extension = Path.GetExtension(accountCreate.UploadAvt.FileName);
                model.Avatar = fileName += extension;
                string path1 = Path.Combine(wwwRootPath + "/img/", fileName);
                using (var fileStream = new FileStream(path1, FileMode.Create))
                {
                    await accountCreate.UploadAvt.CopyToAsync(fileStream);
                }

                var modelTenant = new Tenant
                {
                    DbName = accountCreate.DbName,
                };
                _context.Add(modelTenant);
                _context.Add(model);
                await _context.SaveChangesAsync();
            }    

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


        public async Task<X.PagedList.IPagedList<AccountRequest>> GetListAccountRequestAsync(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var model = new List<AccountRequest>();
            var listAccount = await _context.Accounts.ToListAsync();

            if (listAccount != null)
            {

                foreach (var account in listAccount)
                {
                    var accountRequest = new AccountRequest
                    {
                        AccId = account.AccId,
                        Email = account.Email,
                        Name = account.Name,
                        Avatar = account.Avatar,
                        Role = account.Role,
                        TenantId=account.TenantId
                    };
                    model.Add(accountRequest);
                }
                if (!String.IsNullOrEmpty(searchString))
                {
                    model = model.Where(s => s.Name.Contains(searchString)
                                            || s.Email.Contains(searchString)).ToList();
                }
                model = sortOrder switch
                {
                    "name_desc" => model.OrderByDescending(x => x.Name).ToList(),
                    "name" => model.OrderBy(x => x.Name).ToList(),
                    "id_desc" => model.OrderByDescending(x => x.AccId).ToList(),
                    _ => model.OrderBy(x => x.AccId).ToList(),
                };
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return model.ToPagedList(pageNumber, pageSize);
            }
            return null;
        }
    }
}
