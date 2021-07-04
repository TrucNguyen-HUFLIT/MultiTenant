using MultiTenant.Data.EntitiesTenant.MultiTenants;
using System.Collections.Generic;

namespace MultiTenant.Application.Models.Tenants.Account
{
    public class AccountViewModel
    {
        public AccountEdit AccountEdit { get; set; }
        public AccountRequest AccountRequest { get; set; }
        public ChangeImage ChangeImage { get; set; }
        public List<Tenant> ListTenant { get; set; }
    }
}
