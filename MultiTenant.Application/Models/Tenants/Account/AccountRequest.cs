using System.ComponentModel.DataAnnotations;

namespace MultiTenant.Application.Models.Tenants.Account
{
    public class AccountRequest
    {
        [Display(Name = "ID Account")]
        public int IdAcc { get; set; }

        public string Name { get; set; }

        public string Age { get; set; }

        public string Email { get; set; }
    }
}
