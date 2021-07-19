
namespace MultiTenant.Data.EntitiesTenant.MultiTenants
{
    public  class AccountTenant
    {
        public int AccId { get; set; }
        public Account Account { get; set; }

        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
