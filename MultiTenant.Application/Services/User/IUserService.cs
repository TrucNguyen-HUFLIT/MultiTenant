using MultiTenant.Application.Models;
using MultiTenant.Data.Entities_Tenant;
using ReflectionIT.Mvc.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTenant.Application.Services.User
{
    public interface IUserService
    {
        Task<PagingList<Account>> GetListUsersAsync(string filter, int page, string sortEx = "AccId");
        Task<AccountEdit> GetAccountEditByIdAsync(int id);
        Task<bool> ChangeImageAsync(ChangeImage changeImage);
        Task<bool> EditAsync(AccountEdit accountEdit);
        List<Tenant> GetListTenant();
    }
}
