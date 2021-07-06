using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Application.Models.Tenants.Account;
using MultiTenant.Application.Services.Tenants;
using MultiTenant.Filter;
using System;
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

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            string URL = await _userService.GetURLFromUser(User);
            if (URL != "https://localhost:5002" && StaticAcc.CheckTenant)
            {
                StaticAcc.CheckTenant = false;
                return Redirect(URL);
            }

            await _userService.GetModelByClaimAsync(User);
           
            ViewBag.ActiveAccount = "active";
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("name") ? "name_desc" : "name";

            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            var model = new AccountViewModel
            {
                ListAccountRequest = await _userService.GetListAccountRequestAsync(sortOrder, currentFilter, searchString, page)
            };
            return View(model);

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

        [HttpGet]
        public IActionResult Logout()
        {
            StaticAcc.CheckTenant = true;
            return SignOut("Cookies", "oidc");
        }
    }
}
