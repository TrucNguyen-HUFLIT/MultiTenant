using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Application.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenant.WebApp.Controllers
{
    [Authorize]
    public class AccountManagementController : Controller
    {
        private readonly IUserService _userservice;
        
        public AccountManagementController(IUserService accountService)
        {
            _userservice = accountService;
        }
        public async Task<IActionResult> Index(string filter, int page, string sortEx = "AccId")
        {
            var user = User;
            ViewBag.ActiveAccount = "active";
            return View(await _userservice.GetListUsersAsync(filter, page, sortEx));
        }
        [HttpPost]
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
