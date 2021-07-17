using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenant.Login.Controller.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ConfigurationDbContext _configurationDbContext;
        public TenantController( ConfigurationDbContext configurationDbContext)
        {
            
            _configurationDbContext = configurationDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTenant([FromBody] TenantViewModel model)
        {
            var tenant = new ClientRedirectUri()
            {
                RedirectUri = "https://"+ model.DbName + ".localhost:5002/signin-oidc",
                ClientId = 2,
            };

            _configurationDbContext.Add(tenant);
            await _configurationDbContext.SaveChangesAsync();

            return Ok();
        }



    }
}
