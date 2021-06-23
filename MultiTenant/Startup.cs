using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenant
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddControllersWithViews();
            //services.AddDbContext<Data.Contexts.MultiTenantContext>(options => options.UseSqlServer(@"Server=DESKTOP-I7EOLFR\SQLEXPRESS;Database=MultiTenant;Trusted_Connection=True;"));

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();


            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
               .AddCookie("Cookies")
               .AddOpenIdConnect("oidc", options =>
               {
                   options.SignInScheme = "Cookies";
                   options.Authority = "https://localhost:5000";
                   options.RequireHttpsMetadata = true;

                   options.ClientId = "tenant";
                   options.ClientSecret = "SuperSecretPassword";
                   options.ResponseType = "code";

                   options.UsePkce = true;
                   options.ResponseMode = "query";
                   options.GetClaimsFromUserInfoEndpoint = true;

                   // options.CallbackPath = "/signin-oidc"; // default redirect URI

                   // options.Scope.Add("oidc"); // default scope
                   // options.Scope.Add("profile"); // default scope
                   options.SaveTokens = true;
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
