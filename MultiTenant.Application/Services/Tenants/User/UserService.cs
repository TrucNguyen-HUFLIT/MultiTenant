using Microsoft.EntityFrameworkCore;
using MultiTenant.Application.Models.Tenants.Account;
using MultiTenant.Application.Provider.Tenant;
using MultiTenant.Data.Contexts;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace MultiTenant.Application.Services.Tenants.User
{
    public class UserService : IUserService
    {
        private readonly TenantContext _tenantContext;
        private readonly MultiTenantContext _multiTenantContext;
        private readonly ITenantProvider _tenantProvider;

        public UserService(TenantContext tenantContext, MultiTenantContext multiTenantContext, ITenantProvider tenantProvider)
        {
            _tenantProvider = tenantProvider;
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
            string domain = _tenantProvider.GetDomainFromHost();
            string subdomain = _tenantProvider.GetSubDomainFromHost();

            var claimsVlue = user.Claims
                                .Where(x => x.Type == "tenant_id")
                                .FirstOrDefault().Value;
            string URL = "";
            try
            {
                var listTenantId = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(claimsVlue);

                 URL = $"https://{listTenantId[0]}.{domain}";
                foreach (var tenant_id in listTenantId)
                {
                    if (subdomain == tenant_id)
                    {
                        URL = $"https://{tenant_id}.{domain}";
                        break;
                    }
                }
            }
            catch (Exception)
            {
                if (subdomain == claimsVlue)
                {
                    URL = $"https://{claimsVlue}.{domain}";
                }
            }
           

            return URL;
        }


        public async Task<AccountLogged> GetModelByClaimAsync(ClaimsPrincipal claimsPrincipal)
        {

            string name = claimsPrincipal.Claims
                                .Where(x => x.Type == "name")
                                .FirstOrDefault().Value;
            var account = await _multiTenantContext.Accounts.Where(x => x.UserName == name).FirstOrDefaultAsync();

            var acc = await _multiTenantContext.AccountTenants.Where(x => x.AccId == account.AccId).FirstOrDefaultAsync();

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
                StaticAcc.Favicon = await _multiTenantContext.Tenants.Where(x => x.TenantId == acc.TenantId).Select(x=>x.Favicon).FirstOrDefaultAsync();

                return model;
            }
            else
            {
                return null;
            }

        }
    }
}
