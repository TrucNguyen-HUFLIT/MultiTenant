using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Application.Models.Tenants.Account;
using MultiTenant.Data.Contexts;
using MultiTenant.Data.EntitiesTenant.Tenants;
using ReflectionIT.Mvc.Paging;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenant.Application.Services.Tenants
{
    public class UserService : IUserService
    {
        private readonly TenantContext _context;

        public UserService(TenantContext context)
        {
            _context = context;
        }

        public async Task<PagingList<Account>> GetListUsersAsync(string filter, int page, string sortEx = "IdAcc")
        {

            var qry = _context.Accounts.AsNoTracking().OrderBy(p => p.Email).AsQueryable();
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
            var model = await _context.Accounts
                  .Where(x => x.IdAcc == accountRequest.IdAcc)
                  .FirstOrDefaultAsync();

            model.Name = accountRequest.Name;
            model.Age = accountRequest.Age;

            _context.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AccountRequest> GetAccountRequestByIdAsync(int id)
        {
            var model = await _context.Accounts
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


    }
}
