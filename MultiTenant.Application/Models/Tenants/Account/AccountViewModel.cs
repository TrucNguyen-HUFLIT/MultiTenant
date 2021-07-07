using X.PagedList;

namespace MultiTenant.Application.Models.Tenants.Account
{
    public  class AccountViewModel
    {
        public AccountEdit AccountEdit { get; set; }
        public IPagedList<AccountRequest> ListAccountRequest { get; set; }
        public AccountRequest AccountRequest { get; set; }
    }
}
