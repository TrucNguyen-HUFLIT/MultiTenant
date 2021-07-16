using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiTenant.Application.Provider.Tenant;
using MultiTenant.Application.Services.MultiTenants.AccTenants;
using System.Collections.Generic;
using System.Linq;

namespace MultiTenant.Filter
{
    public class TenantFilter : IActionFilter
    {
        private readonly ITenantProvider _tenantProvider;
        private readonly IAccTenantService _accTenantService;

        public TenantFilter(ITenantProvider tenantProvider, IAccTenantService accTenantService)
        {
            _tenantProvider = tenantProvider;
            _accTenantService = accTenantService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            string domain = await _tenantProvider.GetDomainFromHost();
            string subdomain = await _tenantProvider.GetSubDomainFromHost();

            var claimsVlue = context.HttpContext.User.Claims
                                .Where(x => x.Type == "tenant_id")
                                .FirstOrDefault().Value;

            var listTenantId = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(claimsVlue);

            bool check = true;
            foreach (var tenant_id in listTenantId)
            {
                if (subdomain == tenant_id)
                {
                    check = false;
                    break;
                }
            }
            if (check)
            {
                context.Result = new RedirectResult($"https://{listTenantId[0]}.{domain}");
            }
        }
    }
}
