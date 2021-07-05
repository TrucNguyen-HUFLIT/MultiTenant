using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Application.Models.Tenants.Account;
using MultiTenant.Data.Contexts;
using MultiTenant.Data.EntitiesTenant.Tenants;
using ReflectionIT.Mvc.Paging;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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

        public async Task<PagingList<Account>> GetListUsersAsync(string filter, int page, string sortEx = "IdAcc")
        {
            var qry = _tenantContext.Accounts.AsNoTracking().OrderBy(p => p.Email).AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                qry = qry.Where(p => p.Email.StartsWith(filter));
            }

            var model = await PagingList.CreateAsync(qry, 10, page, sortEx, "IdAcc");

            model.RouteValue = new RouteValueDictionary {
            { "filter", filter}
            };

            return model;
        }

        public async Task<bool> EditAsync(AccountRequest accountRequest)
        {
            var model = await _tenantContext.Accounts
                  .Where(x => x.IdAcc == accountRequest.IdAcc)
                  .FirstOrDefaultAsync();

            model.Name = accountRequest.Name;
            model.Age = accountRequest.Age;

            _tenantContext.Update(model);
            await _tenantContext.SaveChangesAsync();
            return true;
        }

        public async Task<AccountRequest> GetAccountRequestByIdAsync(int id)
        {
            var model = await _tenantContext.Accounts
                .Where(x => x.IdAcc == id)
                .FirstOrDefaultAsync();
            if(model!=null)
            {
                var accountEdit = new AccountRequest
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

        public async Task<string> GetURLFromUser(ClaimsPrincipal user)
        {
            string tenantId  = user.Claims.Where(x=>x.Type == "tenant_id").FirstOrDefault().Value;
            string URL = await _multiTenantContext.Tenants
                                .Where(x => x.DbName == tenantId)
                                .Select(x => x.SubDomain)
                                .FirstOrDefaultAsync();
            
            return URL;
        }
    }
}
