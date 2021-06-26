using System.Collections.Generic;

namespace MultiTenant.Data.EntitiesTenant.MultiTenants
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public string SubDomain { get; set; } 
        public string DataConnectionString { get; set; }
        public string TenantName { get; set; } 
        public string Favicon { get; set; }


        public ICollection<Account> Accounts { get; set; }

    }
}
