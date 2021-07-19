using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Application.Models.MultiTenants.Tenants;
using MultiTenant.Application.Services.MultiTenants.Tenants;
using MultiTenant.WebApp.Filter;
using MultiTenant.WebApp.Helper;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MultiTenant.WebApp.Controllers
{
    [Authorize]
    public class TenantManagementController : Controller
    {
        private readonly ITenantService _tenantservice;
        UserID4API _api = new UserID4API();
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
                listTenantRequest = await _tenantservice.GetListTenantRequestAsync(sortOrder, currentFilter, searchString, page)
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ActiveTenant = "active";
            var model = new TenantViewModel
            {
                tenantEdit = await _tenantservice.GetTenantEditByIdAsync(id),
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ActiveTenant = "active";
            var model = new TenantViewModel
            {
                tenantCreate = new TenantCreate(),
            };
            return View(model);
        }

        [ServiceFilter(typeof(ModelStateAjaxFilter))]
        [TypeFilter(typeof(ExceptionFilter))]
        [HttpPost]
        public async Task<IActionResult> Create(TenantCreate tenantCreate)
        {
            await _tenantservice.CreateAsync(tenantCreate);

            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync("api/APIID4/createtenant", tenantCreate);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return Ok(tenantCreate);
            }
            
            return View();
        }
    }
}
