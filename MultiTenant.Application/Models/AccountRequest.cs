using MultiTenant.Data.Entities_Tenant;
using System.ComponentModel.DataAnnotations;

namespace MultiTenant.Application.Models
{
    public class AccountRequest
    {
        [Display(Name = "ID Acc")]
        public int AccId { get; set; } //Id

        [Display(Name = "Email")]
        public string Email { get; set; }
 
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "First Name ")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name ")]
        public string LastName { get; set; }

        [Display(Name = "Avatar")]
        public string Avatar { get; set; } //Picture

        [Display(Name = "Role")]
        public Role Role { get; set; }

        [Display(Name = "ID Tenant")]
        public int TenantId { get; set; } //ClientID


    }
}
