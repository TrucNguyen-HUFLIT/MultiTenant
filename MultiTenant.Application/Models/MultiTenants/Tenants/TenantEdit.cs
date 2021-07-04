using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiTenant.Application.Models.MultiTenants.Tenants
{
    public class TenantEdit
    {
        [Display(Name ="ID Tenant")]
        public int TenantId { get; set; }
        public string SubDomain { get; set; } //localhost
        public string DbName { get; set; }
        public string Favicon { get; set; }

        [NotMapped]
        [Display(Name = "Favicon")]
        public IFormFile UploadFavicon { get; set; }
    }
}
