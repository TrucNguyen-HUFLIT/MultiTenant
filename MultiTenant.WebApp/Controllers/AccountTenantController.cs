using Microsoft.AspNetCore.Mvc;
using MultiTenant.Application.Models.AccTenants;
using MultiTenant.Application.Services.MultiTenants.AccTenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenant.WebApp.Controllers
{
    public class AccountTenantController : Controller
    {
        private readonly AccTenantService _acctenantservice;

        public AccountTenantController(AccTenantService acctenantService)
        {
            _acctenantservice = acctenantService;
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {

            var model = new AccTenantViewModel
            {
                accTenantRequest = await _acctenantservice.GetAccID(id),
                ListAccTenant = await _acctenantservice.GetListTenantOfAccountAsync(id),
            };
            return View(model);
        }

       // [HttpDelete]
        public async Task<IActionResult> Delete(int tenantId,int accId)
        {
            await _acctenantservice.Delete(tenantId,accId);
            return RedirectToAction("Detail" ,new {id=accId });
        }

        [HttpGet]
        public async Task<IActionResult> AddTenantToAcc(int id)
        {
            var model = new AccTenantViewModel
            {
                ListTenant = _acctenantservice.GetAllListTenant(),
                accTenantRequest = await _acctenantservice.GetAccID(id),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTenantToAcc(AccTenantRequest accTenantRequest)
        {
            await _acctenantservice.AddTenantToAcc(accTenantRequest);
            return RedirectToAction("Detail", new { id = accTenantRequest.AccId });
        }

    }
}
