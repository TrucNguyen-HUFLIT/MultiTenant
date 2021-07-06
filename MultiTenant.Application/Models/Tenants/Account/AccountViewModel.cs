using X.PagedList;

namespace MultiTenant.Application.Models.Tenants.Account
{
    public  class AccountViewModel
    {
        public AccountRequest AccountRequest { get; set; }
        public IPagedList<AccountRequest> ListAccountRequest { get; set; }
    }
}
