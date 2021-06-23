using MultiTenant.Data.Entities_Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Models
{
    public  class AccountViewModel
    {
        public AccountEdit AccountEdit { get; set; }
        public AccountRequest AccountRequest { get; set; }
        public ChangeImage ChangeImage { get; set; }
        public List<Tenant> ListTenant { get; set; }
    }
}
