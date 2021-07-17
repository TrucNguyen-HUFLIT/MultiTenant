using MultiTenant.Data.EntitiesTenant.MultiTenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
