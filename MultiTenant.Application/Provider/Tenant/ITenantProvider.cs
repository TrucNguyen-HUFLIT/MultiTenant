using System.Threading.Tasks;

namespace MultiTenant.Application.Provider.Tenant
{
    public interface ITenantProvider
    {
        Task<string> GetSubDomainFromHost();
        Task<string> GetDomainFromHost();
    }
}
