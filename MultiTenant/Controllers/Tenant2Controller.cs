using Microsoft.AspNetCore.Mvc;
using MultiTenant.Data.Contexts;

namespace MultiTenant.Controllers
{
    public class Tenant2Controller : Controller
    {
        private readonly TenantContext _tenantContext;

        public Tenant2Controller(TenantContext tenantContext)
        {
            _tenantContext = tenantContext;
        }

        public IActionResult Index()
        {
            //string host_dbName = _httpContextAccessor.HttpContext.Request.Host.Value;
            var model = _tenantContext.Accounts.FindAsync(1);
            return View();
        }
    }
}
