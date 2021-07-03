using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Data.Contexts;

namespace MultiTenant.WebApp.Controllers
{
    [Authorize]

    public class ProfileController : Controller
    {
        //private readonly TenantContext _tenantContext;ad
        //public ProfileController(TenantContext tenantContext)
        //{
        //    _tenantContext = tenantContext;
        //}
        public IActionResult Index()
        {
            //var model = _tenantContext.Accounts.FindAsync(3);
            ViewBag.ActiveProfile = "active";
            return View();
        }
    }
}
