using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Data.EntitiesTenant.Tenants
{
    public class Account
    {
        public int IdAcc { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
    }
}
