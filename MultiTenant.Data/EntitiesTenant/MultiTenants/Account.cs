using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MultiTenant.Data.EntitiesTenant.MultiTenants
{
    public class Account
    {
        [Key]
        [Display(Name = "ID Account")]
        public int AccId { get; set; } //Id

        public string Email { get; set; }

        public string Name { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Avatar { get; set; } //Picture

        public Role Role { get; set; }

        public ICollection<AccountTenant> AccountTenants { get; set; }
    }
    public enum Role
    {
        Admin = 1,
        Customer = 2,
    }
}
