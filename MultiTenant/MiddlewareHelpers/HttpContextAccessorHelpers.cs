using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MultiTenant.Extensions;

namespace MultiTenant.MiddlewareHelpers
{
    public static class HttpContextAccessorHelpers
    {
        private static IHttpContextAccessor _contextAccessor;

        public static Microsoft.AspNetCore.Http.HttpContext Current => _contextAccessor?.HttpContext;

        internal static void Configure(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
    }

    public static class HttpContextAccessorExtensions
    {
        public static IApplicationBuilder UseHttpContextAccessor(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.Resolve<IHttpContextAccessor>();
            HttpContextAccessorHelpers.Configure(httpContextAccessor);

            return app;
        }
    }
}
