using System.ComponentModel.DataAnnotations;

namespace MultiTenant.Application.Models.MultiTenants.Tenants
{
    public class TenantRequest
    {
        [Display(Name = "ID Tenant")]
        public int TenantId { get; set; }

        public string URL { get; set; } //localhost

        [Display(Name = "Database Name")]
        public string DbName { get; set; }

        public string Favicon { get; set; }
    }
}
