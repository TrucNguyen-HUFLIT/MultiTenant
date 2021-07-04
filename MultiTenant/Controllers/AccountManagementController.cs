using Microsoft.AspNetCore.Mvc;
using MultiTenant.Application.Models.Tenants.Account;
using MultiTenant.Application.Services.Tenants;
using MultiTenant.Filter;
using System.Threading.Tasks;

namespace MultiTenant.Controllers
{
    public class AccountManagementController : Controller
    {
        private readonly IUserService _userService;

        public AccountManagementController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index(string filter, int page, string sortEx = "IdAcc")
        {
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
    }
}
