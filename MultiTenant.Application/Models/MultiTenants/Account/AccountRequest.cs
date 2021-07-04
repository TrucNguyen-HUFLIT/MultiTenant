
using MultiTenant.Data.EntitiesTenant.MultiTenants;

namespace MultiTenant.Application.Models.MultiTenants.Account
{
    public class AccountRequest
    {
        
        public int AccId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
     
        public string Avatar { get; set; }
        public Role Role { get; set; }
        public int TenantId { get; set; }

    }
}
