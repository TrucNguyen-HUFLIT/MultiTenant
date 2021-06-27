using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiTenant.Controllers
{
    [Authorize]
    public class Tenant1Controller : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction();
        }
    }
}
