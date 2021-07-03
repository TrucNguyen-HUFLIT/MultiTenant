
using MultiTenant.Application.Models.Tenants;
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
        Task<PagingList<Tenant>> GetListTenantsAsync(string filter, int page, string sortEx = "TenantId");
        Task<TenantEdit> GetTenantEditByIdAsync(int id);

    }
}
