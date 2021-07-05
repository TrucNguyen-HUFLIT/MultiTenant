
using MultiTenant.Application.Models.MultiTenants.Tenants;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using ReflectionIT.Mvc.Paging;
using System.Threading.Tasks;
using X.PagedList;

namespace MultiTenant.Application.Services.MultiTenants.Tenants
{
    public interface ITenantService
    {
        Task<TenantEdit> GetTenantEditByIdAsync(int id);
        Task<bool> EditAsync(TenantEdit tenantEdit);

        Task<IPagedList<TenantRequest>> GetListTenantRequestAsync(string sortOrder, string currentFilter, string searchString, int? page);
    }
}
