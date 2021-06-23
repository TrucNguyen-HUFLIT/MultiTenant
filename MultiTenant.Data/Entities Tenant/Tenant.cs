using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Data.Entities_Tenant
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public string SubDomain { get; set; } //localhost
        public string DataConnectionString { get; set; }
        public string TenantName { get; set; } 
        public string Favicon { get; set; }

        public ICollection<Account> Accounts { get; set; }

    }
}
