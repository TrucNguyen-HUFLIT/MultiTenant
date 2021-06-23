using Microsoft.AspNetCore.Mvc;

namespace MultiTenant.Controllers
{
    public class Tenant1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
