﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Models.Tenants.Account
{
    public class AccountRequest
    {
        [Display(Name = "ID Account")]
        public int IdAcc { get; set; }

        public string Name { get; set; }

        public string Age { get; set; }

        public string Email { get; set; }
    }
}
