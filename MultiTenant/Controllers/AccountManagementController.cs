using Microsoft.AspNetCore.Mvc;

namespace MultiTenant.Controllers
{
    public class AccountManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
