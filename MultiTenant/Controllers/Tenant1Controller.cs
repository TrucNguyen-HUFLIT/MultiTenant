using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Data.Contexts;

namespace MultiTenant.Controllers
{
    public class Tenant1Controller : Controller
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public Tenant1Controller(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}

        private readonly TenantContext _tenantContext;

        public Tenant1Controller(TenantContext tenantContext)
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
