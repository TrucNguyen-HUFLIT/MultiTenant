
using MultiTenant.Application.Models.MultiTenant.Tenants;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using ReflectionIT.Mvc.Paging;
using System.Threading.Tasks;

namespace MultiTenant.Application.Services.MultiTenants.Tenants
{
    public interface ITenantService
    {
        Task<PagingList<Tenant>> GetListTenantsAsync(string filter, int page, string sortEx = "TenantId");
        Task<TenantEdit> GetTenantEditByIdAsync(int id);

    }
}
