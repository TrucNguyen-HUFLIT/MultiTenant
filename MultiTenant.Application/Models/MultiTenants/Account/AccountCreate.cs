using Microsoft.AspNetCore.Http;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiTenant.Application.Models.MultiTenants.Account
{
    public class AccountCreate
    {
        //[Display(Name = "ID Account")]
        //public int AccId { get; set; }

        public string Name { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Avatar { get; set; }

        public Role Role { get; set; }

        [NotMapped]
        [Display(Name = "Avatar")]
        public IFormFile UploadAvt { get; set; }


    }
}
