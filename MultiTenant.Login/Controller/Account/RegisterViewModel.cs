using MultiTenant.Data.EntitiesTenant.MultiTenants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenant.Login.Controller.Account
{
    public class RegisterViewModel
    {
        //[Display(Name = "ID Account")]
       // public int AccId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public Role Role { get; set; }

    }
}
