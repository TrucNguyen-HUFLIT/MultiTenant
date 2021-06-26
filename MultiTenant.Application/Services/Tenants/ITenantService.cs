
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Services.Tenants
{
    public interface ITenantService
    {
        Task<PagingList<Tenant>> GetListUsersAsync(string filter, int page, string sortEx = "TenantName");
    }
}
