using MultiTenant.Data.Entities_Tenant;
using System.ComponentModel.DataAnnotations;

namespace MultiTenant.Application.Models
{
    public  class AccountEdit
    {
        [Display(Name = "ID Acc")]
        public int AccId { get; set; } //Id

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Avatar")]
        public string Avatar { get; set; } //Picture

        [Display(Name = "Role")]
        public Role Role { get; set; }

        [Display(Name = "ID Tenant")]
        public int TenantId { get; set; } //ClientID

    }
}
