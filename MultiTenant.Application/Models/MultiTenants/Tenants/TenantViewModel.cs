
using MultiTenant.Application.Models.MultiTenants.Tenants;
using X.PagedList;

namespace MultiTenant.Application.Models.MultiTenants.Tenants
{
    public class TenantViewModel
    {
        public TenantEdit tenantEdit { get; set; }
        public IPagedList<TenantRequest> listTenantRequest { get; set; }
        public TenantRequest tenantRequest { get; set; }
    }
}
