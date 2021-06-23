using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.WebApp.Filter;
using MultiTenant.Application.Services.User;
using MultiTenant.Application.Validators.User;
using ReflectionIT.Mvc.Paging;
using System.IdentityModel.Tokens.Jwt;

namespace MultiTenant.WebApp
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

            services.AddDbContext<Data.Contexts.MultiTenantContext>(options => options.UseSqlServer(@"Server=DESKTOP-I7EOLFR\SQLEXPRESS;Database=MultiTenant;Trusted_Connection=True;"));

            services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap4";
                options.PageParameterName = "page";
            });

            services.AddMvc(
                option =>
                {
                    option.Filters.Add(typeof(ExceptionFilter));
                }
                ).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest)
                .AddFluentValidation(option =>
                {
                    option.RegisterValidatorsFromAssemblyContaining<AccountEditValidator>();
                   
                });

            services.AddControllersWithViews();

            services.AddScoped<ModelStateAjaxFilter>();

            services.AddScoped<IUserService, UserService>();

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

                   options.ClientId = "mgmt";
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
                    pattern: "{controller=Profile}/{action=Index}/{id?}");
            });
        }
    }
}
