
namespace MultiTenant.Application.Provider.Tenant
{
    public interface ITenantProvider
    {
        string GetSubDomainFromHost();
        string GetDomainFromHost();
    }
}
