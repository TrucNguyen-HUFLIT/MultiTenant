using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenant.WebApp.Controllers
{
    public class TenantManagementController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ActiveTenant = "active";
            return View();
        }
    }
}
