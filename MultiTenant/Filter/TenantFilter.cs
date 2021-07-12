using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace MultiTenant.Filter
{
    public class TenantFilter : IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TenantFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string host = _httpContextAccessor.HttpContext.Request.Host.Value;
            string[] subDomain = host.Split(".");
            //if (subDomain.Length == 1)
            //    subDomain[0] = null;

            string tenant_id = context.HttpContext.User.Claims
                                .Where(x => x.Type == "tenant_id")
                                .FirstOrDefault().Value;

            //if (tenant_id == "Tenant")
            //{
            //    tenant_id = null;
            //    sub = tenant_id;
            //}

            if (subDomain[0] != tenant_id)
            {
                context.Result = new RedirectResult($"{tenant_id}.{subDomain[1]}");
            }    
        }
    }
}
