
using MultiTenant.Application.Models.Account;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Services.User
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
