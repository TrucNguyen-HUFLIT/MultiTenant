using System.ComponentModel.DataAnnotations;

namespace MultiTenant.Application.Models.MultiTenant.Tenants

{
    public  class TenantEdit
    {
        [Display(Name ="ID Tenant")]
        public int TenantId { get; set; }
        public string SubDomain { get; set; } //localhost
        public string DbName { get; set; }
        public string Favicon { get; set; }


    }
}
