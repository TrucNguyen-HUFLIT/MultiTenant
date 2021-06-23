using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Models
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
