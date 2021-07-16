
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MultiTenant.Application.Provider.Tenant
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> GetSubDomainFromHost()
        {
            string host = _httpContextAccessor.HttpContext.Request.Host.Value;
            string[] subdomain = host.Split(".");

            return subdomain[0];
        }
        public async Task<string> GetDomainFromHost()
        {
            string host = _httpContextAccessor.HttpContext.Request.Host.Value;
            string[] subdomain = host.Split(".");

            return subdomain[1];
        }
    }
}
