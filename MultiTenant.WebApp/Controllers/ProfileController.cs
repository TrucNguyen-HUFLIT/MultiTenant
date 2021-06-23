using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiTenant.WebApp.Controllers
{
    [Authorize]

    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ActiveProfile = "active";
            return View();
        }
    }
}
