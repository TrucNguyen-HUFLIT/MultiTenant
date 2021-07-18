using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Login.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MultiTenant.Login.Controller.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteTenantController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public DeleteTenantController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TenantAccViewModel model)
        {

            var user = await _userManager.FindByNameAsync(model.UserName);

            Claim c = new ("tenant_id", model.DbName);

            await _userManager.RemoveClaimAsync(user, c);

            return Ok();

        }
    }
}
