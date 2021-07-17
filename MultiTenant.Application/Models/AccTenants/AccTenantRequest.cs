using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Models.AccTenants
{
    public class AccTenantRequest
    {
        [Display(Name = "Account")]
        public int AccId { get; set; }
        public string NameAcc { get; set; }
        public string UserName { get; set; }

        [Display(Name = "Tenant")]
        public int TenantId { get; set; }

        public string URL { get; set; } //localhost

        [Display(Name = "Database Name")]
        public string DbName { get; set; }

        public string Favicon { get; set; }
    }
}
