
using MultiTenant.Application.Models.MultiTenants.Tenants;
using X.PagedList;

namespace MultiTenant.Application.Models.MultiTenants.Tenants
{
    public class TenantViewModel
    {
        public TenantEdit TenantEdit { get; set; }
        public IPagedList<TenantRequest> ListTenantRequest { get; set; }
        public TenantRequest TenantRequest { get; set; }
    }
}
