using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenant.Login.Controller.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public RegisterController( UserManager<IdentityUser> userManager, ConfigurationDbContext configurationDbContext)
        {
            _userManager = userManager;
          
        }

        [HttpPost]
        public IActionResult Create([FromBody] RegisterViewModel model)
        {
            //var user1 = _userManager.FindByNameAsync("kha");

            //DbName = Subdomain
            //string tenant = await _context.Tenants.Where(x => x.TenantId == model.TenantId).Select(x => x.DbName).FirstOrDefaultAsync();
            //var tenant = await _context.Tenants.ToListAsync();
            TestUser user = new()
            {
                Username = model.UserName,
                Password = model.Password,
                Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, model.Email),
                        new Claim(JwtClaimTypes.Role, "customer"),
                        new Claim(JwtClaimTypes.ClientId, "tenant"),
                        //new Claim("tenant_id", tenant)
                    }
            };
            var identityUser = new IdentityUser(user.Username)
            {
                Email = model.Email,
            };

            _userManager.CreateAsync(identityUser, user.Password.ToString()).Wait();
            _userManager.AddClaimsAsync(identityUser, user.Claims.ToList()).Wait();
 
            return Ok();

        }

    }
}
