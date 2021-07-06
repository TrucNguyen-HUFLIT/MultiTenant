using MultiTenant.Data.EntitiesTenant.MultiTenants;
using System.ComponentModel.DataAnnotations;

namespace MultiTenant.Application.Models.MultiTenants.Account
{
    public  class AccountEdit
    {
        [Display(Name ="ID Account")]
        public int AccId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Avatar { get; set; }

        public Role Role { get; set; }

        [Display(Name = "ID Tenant")]
        public int TenantId { get; set; }

    }
}
