using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Data.Contexts;
using MultiTenant.Models;
using System.Diagnostics;

namespace MultiTenant.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly TenantContext _tenantContext;

        public HomeController( TenantContext tenantContext)
        {
            _tenantContext = tenantContext;
        }

        public IActionResult Index()
        {
            var model = _tenantContext.Accounts.FindAsync(1);
            var user = User;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
