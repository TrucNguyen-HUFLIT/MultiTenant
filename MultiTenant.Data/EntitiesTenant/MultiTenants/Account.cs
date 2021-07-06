using System.ComponentModel.DataAnnotations;

namespace MultiTenant.Data.EntitiesTenant.MultiTenants
{
    public class Account
    {
        [Display(Name = "ID Account")]
        public int AccId { get; set; } //Id

        public string Email { get; set; }

        public string Name { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Avatar { get; set; } //Picture

        public Role Role { get; set; }

        [Display(Name = "ID Tenant")]
        public int TenantId { get; set; } //ClientID

        public Tenant Tenant { get; set; }
    }
    public enum Role
    {
        Admin = 1,
        Customer = 2,
    }
}
