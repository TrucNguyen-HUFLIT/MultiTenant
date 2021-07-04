
using MultiTenant.Application.Models.MultiTenants.Account;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using ReflectionIT.Mvc.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTenant.Application.Services.MultiTenants.User
{
    public interface IUserService
    {
        
        Task<PagingList<Account>> GetListUsersAsync(string filter, int page, string sortEx = "AccId");
        Task<AccountEdit> GetAccountEditByIdAsync(int id);
        Task<bool> ChangeImageAsync(ChangeImage changeImage);
        Task<bool> EditAsync(AccountEdit accountEdit);
        Task CreateAsync(AccountCreate accountCreate);
        List<Tenant> GetListTenant();
       
    }
}
