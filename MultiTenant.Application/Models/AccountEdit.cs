using Microsoft.AspNetCore.Http;
using MultiTenant.Data.Entities_Tenant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Models
{
    public  class AccountEdit
    {
        public int AccId { get; set; }
        public string Email { get; set; }
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public Role Role { get; set; }
        public int TenantId { get; set; }

        [NotMapped]
        public IFormFile UploadAvt { get; set; }
    }
}
