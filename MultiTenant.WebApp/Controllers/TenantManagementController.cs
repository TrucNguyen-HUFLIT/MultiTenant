using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Application.Models.Tenants;
using MultiTenant.Application.Services.Tenants;
using System.Threading.Tasks;

namespace MultiTenant.WebApp.Controllers
{
    [Authorize]
    public class TenantManagementController : Controller
    {
        private readonly ITenantService _tenantservice;

        public TenantManagementController(ITenantService tenantService)
        {
            _tenantservice = tenantService;
        }

        public async Task<IActionResult> Index(string filter, int page, string sortEx = "TenantId")
        {
            ViewBag.ActiveTenant = "active";
            return View(await _tenantservice.GetListTenantsAsync(filter, page, sortEx));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ActiveAccount = "active";
            var model = new TenantViewModel
            {
                TenantEdit = await _tenantservice.GetTenantEditByIdAsync(id),
            };
            return View(model);
        }
    }
}
