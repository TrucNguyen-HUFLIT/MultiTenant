using MultiTenant.Application.Models;
using MultiTenant.Data.Entities_Tenant;
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
        AccountEdit GetAccountEditById(int id);
        Task<bool> EditAsync(AccountEdit accountEdit);
    }
}
