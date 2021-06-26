using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Models.Tenants
{
    class TenantEdit
    {
        [Display(Name ="ID Tenant")]
        public int TenantId { get; set; }
        public string SubDomain { get; set; } //localhost
        public string DataConnectionString { get; set; }
        public string TenantName { get; set; }
        public string Favicon { get; set; }


    }
}
