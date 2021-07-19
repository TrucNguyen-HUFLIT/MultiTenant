using MultiTenant.Data.EntitiesTenant.MultiTenants;
using System.Collections.Generic;

namespace MultiTenant.Application.Models.AccTenants
{
    public class AccTenantViewModel
    {
        public AccTenantRequest accTenantRequest;

        public List<Tenant> ListAccTenant;

        public List<Tenant> ListTenant;

        public AccTenantDelete accTenantDelete;

     
    }
}
