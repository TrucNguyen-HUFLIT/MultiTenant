using Microsoft.AspNetCore.Mvc;
using MultiTenant.Application.Models.AccTenants;
using MultiTenant.Application.Services.MultiTenants.AccTenants;
using MultiTenant.WebApp.Helper;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MultiTenant.WebApp.Controllers
{
    public class AccountTenantController : Controller
    {
        private readonly AccTenantService _acctenantservice;
        UserID4API _api = new UserID4API();
        public AccountTenantController(AccTenantService acctenantService)
        {
            _acctenantservice = acctenantService;
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            ViewBag.ActiveAccount = "active";

            var model = new AccTenantViewModel
            {
                accTenantRequest = await _acctenantservice.GetAccID(id),
                ListAccTenant = await _acctenantservice.GetListTenantOfAccountAsync(id),
            };
            return View(model);
        }

        public async Task<IActionResult> Delete(AccTenantDelete accTenantDelete)
        {
            await _acctenantservice.Delete(accTenantDelete);
            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync("api/deletetenant", accTenantDelete);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return Ok(accTenantDelete);
            }
            return Ok(accTenantDelete);
        }

        [HttpGet]
        public async Task<IActionResult> AddTenantToAcc(int id)
        {
            ViewBag.ActiveAccount = "active";

            var model = new AccTenantViewModel
            {
                ListTenant = await _acctenantservice.GetAllListTenant(id),
                accTenantRequest = await _acctenantservice.GetAccID(id),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTenantToAcc(AccTenantRequest accTenantRequest)
        {
            accTenantRequest = await _acctenantservice.SetDbNameToTenant(accTenantRequest);
            await _acctenantservice.AddTenantToAcc(accTenantRequest);

            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync("api/acctenant", accTenantRequest);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return Ok(accTenantRequest);
            }

            return RedirectToAction("Detail", new { id = accTenantRequest.AccId });
        }

    }
}
