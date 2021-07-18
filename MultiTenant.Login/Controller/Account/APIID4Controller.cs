using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Login.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenant.Login.Controller.Account
{
    [Route("api/APIID4")]
    [ApiController]
    public class APIID4Controller : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ConfigurationDbContext _configurationDbContext;
        public APIID4Controller( UserManager<IdentityUser> userManager, ConfigurationDbContext configurationDbContext)
        {
            _userManager = userManager;
            _configurationDbContext = configurationDbContext;
        }

        //CreateAccount
        [HttpPost("createacc")]
        public IActionResult Create([FromBody] RegisterViewModel model)
        {
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
        
        [Route("createtenant")]
        //CreateTenant
        [HttpPost]
        public async Task<IActionResult> CreateTenant([FromBody] TenantViewModel model)
        {
            var tenant = new ClientRedirectUri()
            {
                RedirectUri = "https://" + model.DbName + ".localhost:5002/signin-oidc",
                ClientId = 2,
            };

            _configurationDbContext.Add(tenant);
            await _configurationDbContext.SaveChangesAsync();

            return Ok();
        }

        //AddClaim
        [HttpPost("addclaim")]
        public async Task<IActionResult> AddClaim([FromBody] TenantAccViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            var claim = new List<Claim>
            {
                new Claim("tenant_id", model.DbName)
            };

            await _userManager.AddClaimsAsync(user, claim);
            return Ok();
        }

        //DeleteClaimTenantID
        [HttpPost("deleteclaim")]
        public async Task<IActionResult> Delete(TenantAccViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            Claim c = new("tenant_id", model.DbName);

            await _userManager.RemoveClaimAsync(user, c);

            return Ok();
        }
    }
}
