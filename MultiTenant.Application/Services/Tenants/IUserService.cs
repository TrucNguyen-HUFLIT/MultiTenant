using MultiTenant.Application.Models.Tenants.Account;
using MultiTenant.Data.EntitiesTenant.Tenants;
using ReflectionIT.Mvc.Paging;
using System.Threading.Tasks;

namespace MultiTenant.Application.Services.Tenants
{
    public interface IUserService
    {
        Task<PagingList<Account>> GetListUsersAsync(string filter, int page, string sortEx = "AccId");
        Task<AccountRequest> GetAccountRequestByIdAsync(int id);
        Task<bool> EditAsync(AccountRequest accountRequest);
    }
}
