using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Application.Models.MultiTenants.Tenants;
using MultiTenant.Application.Services.MultiTenants.Tenants;
using MultiTenant.WebApp.Filter;
using System;
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

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.ActiveTenant = "active";
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DbNameSortParm = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("name") ? "name_desc" : "name";

            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            var model = new TenantViewModel
            {
                ListTenantRequest = await _tenantservice.GetListTenantRequestAsync(sortOrder, currentFilter, searchString, page)
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ActiveTenant = "active";
            var model = new TenantViewModel
            {
                TenantEdit = await _tenantservice.GetTenantEditByIdAsync(id),
            };
            return View(model);
        }
        [ServiceFilter(typeof(ModelStateAjaxFilter))]
        [TypeFilter(typeof(ExceptionFilter))]
        [HttpPost]
        public async Task<IActionResult> Edit(TenantEdit tenantEdit)
        {
            await _tenantservice.EditAsync(tenantEdit);
            return Ok(tenantEdit.TenantId);
        }
    }
}
