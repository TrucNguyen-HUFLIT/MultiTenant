using Microsoft.AspNetCore.Mvc;

namespace MultiTenant.Controllers
{
    public class Tenant2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
