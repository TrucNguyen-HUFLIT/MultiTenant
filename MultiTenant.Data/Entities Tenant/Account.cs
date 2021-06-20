using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Data.Entities_Tenant
{
    public class Account
    {
        public int AccId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public Role Role { get; set; }
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
    public enum Role
    {
        Admin = 1,
        Customer = 2,
    }
}
