using MultiTenant.Data.EntitiesTenant.MultiTenants;
using System.Collections.Generic;
using X.PagedList;

namespace MultiTenant.Application.Models.MultiTenants.Account
{
    public class AccountViewModel
    {
        public AccountCreate accountCreate { get; set; }
        public AccountEdit accountEdit { get; set; }
        public AccountRequest accountRequest { get; set; }
        public ChangeImage ChangeImage { get; set; }
        public List<Tenant> listTenant { get; set; }
        public IPagedList<AccountRequest> ListAccountRequest { get; set; }
    }
}
