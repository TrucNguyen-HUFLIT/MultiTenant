using MultiTenant.Application.Models.Tenants.Account;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace MultiTenant.Application.Services.Tenants
{
    public interface IUserService
    {
        Task<AccountLogged> GetModelByClaimAsync(ClaimsPrincipal claimsPrincipal);
        Task<IPagedList<AccountRequest>> GetListAccountRequestAsync(string sortOrder, string currentFilter, string searchString, int? page);
        Task<AccountRequest> GetAccountRequestByIdAsync(int id);
        Task<bool> EditAsync(AccountRequest accountRequest);
        Task<string> GetURLFromUser(ClaimsPrincipal claimsPrincipal);
    }
}
