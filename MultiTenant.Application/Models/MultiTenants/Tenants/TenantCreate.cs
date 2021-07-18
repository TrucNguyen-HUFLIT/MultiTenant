using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Models.MultiTenants.Tenants
{
   public  class TenantCreate
    {
        [Display(Name = "ID Tenant")]
        public int TenantId { get; set; }
        public string URL { get; set; } //localhost
        [Display(Name = "Database Name (subdomain)")]
        public string DbName { get; set; }
        public string Favicon { get; set; }

        [NotMapped]
        [Display(Name = "Favicon")]
        public IFormFile UploadFavicon { get; set; }
    }
}
