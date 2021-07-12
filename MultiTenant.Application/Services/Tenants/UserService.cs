using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Application.Models.Tenants.Account;
using MultiTenant.Data.Contexts;
using MultiTenant.Data.EntitiesTenant.Tenants;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace MultiTenant.Application.Services.Tenants
{
    public class UserService : IUserService
    {
        private readonly TenantContext _tenantContext;
        private readonly MultiTenantContext _multiTenantContext;

        public UserService(TenantContext tenantContext, MultiTenantContext multiTenantContext)
        {
            _tenantContext = tenantContext;
            _multiTenantContext = multiTenantContext;
        }

        public async Task<bool> EditAsync(AccountEdit accountEdit)
        {
            var model = await _tenantContext.Accounts
                  .Where(x => x.IdAcc == accountEdit.IdAcc)
                  .FirstOrDefaultAsync();

            model.Name = accountEdit.Name;
            model.Age = accountEdit.Age;

            _tenantContext.Update(model);
            await _tenantContext.SaveChangesAsync();
            return true;
        }

        public async Task<AccountEdit> GetAccountEditByIdAsync(int id)
        {
            var model = await _tenantContext.Accounts
                .Where(x => x.IdAcc == id)
                .FirstOrDefaultAsync();
            if(model!=null)
            {
                var accountEdit = new AccountEdit
                {
                    IdAcc = model.IdAcc,
                    Name = model.Name,
                    Age = model.Age,
                    Email = model.Email,
                };
                return accountEdit;
            }
            return null;
        }

        public async Task<IPagedList<AccountRequest>> GetListAccountRequestAsync(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var model = new List<AccountRequest>();
            var listAccount = await _tenantContext.Accounts.ToListAsync();

            if (listAccount != null)
            {
                foreach (var account in listAccount)
                {
                    var accountRequest = new AccountRequest
                    {
                        IdAcc = account.IdAcc,
                        Email = account.Email,
                        Name = account.Name,
                        Age = account.Age,
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
                    "id_desc" => model.OrderByDescending(x => x.IdAcc).ToList(),
                    _ => model.OrderBy(x => x.IdAcc).ToList(),
                };
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return model.ToPagedList(pageNumber, pageSize);
            }

            return null;

        }

        public async Task<string> GetURLFromUser(ClaimsPrincipal user)
        {
            string tenantId = user.Claims
                                .Where(x => x.Type == "tenant_id")
                                .FirstOrDefault().Value;
            string URL = await _multiTenantContext.Tenants
                                .Where(x => x.DbName == tenantId)
                                .Select(x => x.URL)
                                .FirstOrDefaultAsync();
            return URL;
        }


        public async Task<AccountLogged> GetModelByClaimAsync(ClaimsPrincipal claimsPrincipal)
        {

            string name = claimsPrincipal.Claims
                                .Where(x => x.Type == "name")
                                .FirstOrDefault().Value;
            var account = await _multiTenantContext.Accounts.Where(x => x.UserName == name).FirstOrDefaultAsync();

            if (account != null)
            {
                var model = new AccountLogged
                {
                    IdAcc = account.AccId,
                    Email = account.Email,
                    Name = account.Name,
                    Avatar = account.Avatar,
                };

                StaticAcc.Avatar = model.Avatar;
                StaticAcc.Name = model.Name;
                StaticAcc.Email = model.Email;
               // StaticAcc.Favicon = await _multiTenantContext.Tenants.Where(x => x.TenantId == account.TenantId).Select(x => x.Favicon).FirstOrDefaultAsync();

                return model;
            }
            else
            {
                return null;
            }

        }
    }
}
