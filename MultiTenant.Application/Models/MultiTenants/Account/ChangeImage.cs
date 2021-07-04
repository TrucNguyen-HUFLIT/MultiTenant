using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MultiTenant.Application.Models.MultiTenants.Account
{
    public class ChangeImage
    {
        [Display(Name = "ID Account")]
        public int AccId { get; set; }
        [Display(Name = "Avatar")]
        public string Avatar { get; set; }
        public IFormFile UploadAvt { get; set; }
    }
}
