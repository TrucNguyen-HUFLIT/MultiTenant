
using MultiTenant.Application.Models.MultiTenants.Account;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace MultiTenant.Application.Services.MultiTenants.User
{
    public interface IUserService
    {
        Task<AccountEdit> GetAccountEditByIdAsync(int id);
        Task<bool> ChangeImageAsync(ChangeImage changeImage);
        Task<bool> EditAsync(AccountEdit accountEdit);
        Task CreateAsync(AccountCreate accountCreate);
        List<Tenant> GetListTenant();
        Task<IPagedList<AccountRequest>> GetListAccountRequestAsync(string sortOrder, string currentFilter, string searchString, int? page);
    }
}
