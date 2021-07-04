﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.WebApp.Filter;
using System.Threading.Tasks;
using MultiTenant.Application.Services.MultiTenants.User;
using MultiTenant.Application.Models.MultiTenants.Account;

namespace MultiTenant.WebApp.Controllers
{
    [Authorize]
    public class AccountManagementController : Controller
    {
        private readonly IUserService _accountservice;
        
        public AccountManagementController(IUserService accountService)
        {
            _accountservice = accountService;
        }
        public async Task<IActionResult> Index(string filter, int page, string sortEx = "AccId")
        {
            var user = User;
            ViewBag.ActiveAccount = "active";
            return View(await _accountservice.GetListUsersAsync(filter, page, sortEx));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ActiveAccount = "active";
            var model = new AccountViewModel
            {
                ListTenant = _accountservice.GetListTenant(),
                AccountEdit = await _accountservice.GetAccountEditByIdAsync(id)

            };
            return View(model);
        }
        [ServiceFilter(typeof(ModelStateAjaxFilter))]
        [HttpPost]
        public async Task<IActionResult> Edit(AccountEdit accountEdit)
        {
            await _accountservice.EditAsync(accountEdit);
            return Ok(accountEdit.AccId);
        }

        public async Task<IActionResult> ChangeImageEdit(ChangeImage changeImage)
        {
            await _accountservice.ChangeImageAsync(changeImage);
            return RedirectToAction("Edit", new { id = changeImage.AccId });
        }
        [HttpPost]
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
