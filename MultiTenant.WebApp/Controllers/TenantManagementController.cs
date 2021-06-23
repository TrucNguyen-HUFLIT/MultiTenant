using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiTenant.WebApp.Controllers
{
    [Authorize]
    public class TenantManagementController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ActiveTenant = "active";
            return View();
        }
    }
}
