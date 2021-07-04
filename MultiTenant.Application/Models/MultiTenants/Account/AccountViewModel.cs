﻿using MultiTenant.Data.EntitiesTenant.MultiTenants;
using System.Collections.Generic;
using X.PagedList;

namespace MultiTenant.Application.Models.MultiTenants.Account
{
    public class AccountViewModel
    {
        public AccountEdit AccountEdit { get; set; }
        public AccountRequest AccountRequest { get; set; }
        public ChangeImage ChangeImage { get; set; }
        public List<Tenant> ListTenant { get; set; }

        public IPagedList<AccountRequest> ListAccountRequest { get; set; }
    }
}
