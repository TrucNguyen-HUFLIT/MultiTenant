using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Data.Contexts;
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
            services.AddDbContext<MultiTenantContext>();

            services.AddDbContext<TenantContext>((provider,options )=>
            {
                var context = provider.GetRequiredService<MultiTenantContext>();
                var tenantId =  context.Accounts.Where(x=>x.UserName == "huy").Select(x=>x.TenantId).FirstOrDefault();
                var databaseName = context.Tenants.Where(x => x.TenantId == tenantId).Select(x=>x.DataConnectionString).FirstOrDefault();

                options.UseSqlServer($@"Server=DESKTOP-I7EOLFR\SQLEXPRESS;Database={databaseName};Trusted_Connection=True;");
            });

            services.AddSingleton<SubdomainRouteTransformer>();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultSignInScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
               .AddCookie("Cookies")
               .AddOpenIdConnect("oidc", "tenant", options =>
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
               })
               //.AddOpenIdConnect("oidc", "tenant1", options =>
               //{
               //    options.SignInScheme = "Cookies";
               //    options.Authority = "https://localhost:5000";
               //    options.RequireHttpsMetadata = true;

               //    options.ClientId = "tenant1";
               //    options.ClientSecret = "SuperSecretPassword";
               //    options.ResponseType = "code";

               //    options.UsePkce = true;
               //    options.ResponseMode = "query";
               //    options.GetClaimsFromUserInfoEndpoint = true;

               //    options.CallbackPath = "/signin-oidc"; // default redirect URI

               //    options.Scope.Add("oidc"); // default scope
               //    options.Scope.Add("profile"); // default scope
               //    options.SaveTokens = true;
               //})
               ;
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

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDynamicControllerRoute<SubdomainRouteTransformer>("{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public class SubdomainRouteTransformer : DynamicRouteValueTransformer
    {
        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            var subDomain = httpContext.Request.Host.Host.Split(".").First(); //tenant1.localhost --> tenant1

            if (!string.IsNullOrEmpty(subDomain))
            {
                if (subDomain == "localhost")
                {
                    return values;
                }
                values["controller"] = subDomain;
            }
            return values;
        }
    }
}
