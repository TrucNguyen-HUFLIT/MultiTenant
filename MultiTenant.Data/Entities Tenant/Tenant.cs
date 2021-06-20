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

        public string Host { get; set; }
        public string DatabaseConnection { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Favicon { get; set; }

        public ICollection<Account> Accounts { get; set; }

    }
}
