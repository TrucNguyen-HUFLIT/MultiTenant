using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Application.Models.AccTenants;
using MultiTenant.Login.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MultiTenant.Login.Controller.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccTenantController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccTenantController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TenantAccViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            var claim = new List<Claim>
            {
                new Claim("tenant_id", model.DbName)
            };

            await _userManager.AddClaimsAsync(user, claim);
            return Ok();
        }

    }
}
