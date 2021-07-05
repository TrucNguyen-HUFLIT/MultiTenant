using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Application.Models.Tenants.Account;
using MultiTenant.Application.Services.Tenants;
using MultiTenant.Filter;
using System.Threading.Tasks;

namespace MultiTenant.Controllers
{
    [Authorize]
    public class AccountManagementController : Controller
    {
        private readonly IUserService _userService;

        public AccountManagementController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index(string filter, int page, string sortEx = "IdAcc")
        {
            string URL = await _userService.GetURLFromUser(User);
            if(URL != "Tenant" && StaticAcc.CheckTenant)
            {
                StaticAcc.CheckTenant = false;
                return Redirect(URL);
            }  
            
            ViewBag.ActiveAccount = "active";
            return View(await _userService.GetListUsersAsync(filter, page, sortEx));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ActiveAccount = "active";
            return View(await _userService.GetAccountRequestByIdAsync(id));
        }

        [ServiceFilter(typeof(ModelStateAjaxFilter))]
        [HttpPost]
        public async Task<IActionResult> Edit(AccountRequest accountRequest)
        {
            await _userService.EditAsync(accountRequest);
            return Ok(accountRequest.IdAcc);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            StaticAcc.CheckTenant = true;
            return SignOut("Cookies", "oidc");
        }
    }
}
