using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiTenant.Application.Provider.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiTenant.Filter
{
    public class TenantFilter : IActionFilter
    {
        private readonly ITenantProvider _tenantProvider;

        public TenantFilter(ITenantProvider tenantProvider)
        {
            _tenantProvider = tenantProvider;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string domain = _tenantProvider.GetDomainFromHost();
            string subdomain = _tenantProvider.GetSubDomainFromHost();

            var claimsVlue = context.HttpContext.User.Claims
                                .Where(x => x.Type == "tenant_id")
                                .FirstOrDefault().Value;

            try
            {
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
            catch (Exception)
            {
                if (subdomain != claimsVlue)
                {
                    context.Result = new RedirectResult($"https://{claimsVlue}.{domain}");
                }
            }


           
        }
    }
}
