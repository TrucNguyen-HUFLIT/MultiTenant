using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.WebApp.Filter;
using System.Threading.Tasks;
using MultiTenant.Application.Services.MultiTenants.User;
using MultiTenant.Application.Models.MultiTenants.Account;
using System;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using System.Linq;

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
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.ActiveAccount = "active";
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("name") ? "name_desc" : "name";
           
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

            StaticAcc.Name = User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value;

            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            var model = new AccountViewModel
            {
                ListAccountRequest = await _accountservice.GetListAccountRequestAsync(sortOrder, currentFilter, searchString, page)
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create(string message)
        {

            ViewBag.error = message;
            var model = new AccountViewModel
            {
                AccountCreate = new AccountCreate(),
                ListTenant = _accountservice.GetListTenant(),
            };
            return View(model);
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

        [HttpGet]
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountCreate accountCreate)
        {
            await _accountservice.CreateAsync(accountCreate);
            return Ok(accountCreate.AccId);
        }
    }
}
