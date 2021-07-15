using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenant.Login.Controller.Account
{
    public class TenantViewModel
    {
        public string RedirectURI { get; set; }
        public int ClientID { get; set; }

    }
}
