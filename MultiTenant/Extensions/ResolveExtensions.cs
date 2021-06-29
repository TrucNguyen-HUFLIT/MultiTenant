using Microsoft.AspNetCore.Builder;
using System;
using Microsoft.Extensions.DependencyInjection;
namespace MultiTenant.Extensions
{
    public static class ResolveExtensions
    {
        public static T Resolve<T>(this IApplicationBuilder applicationBuilder) where T : class
        {
            return applicationBuilder.ApplicationServices.Resolve<T>();
        }

        public static T Resolve<T>(this IServiceProvider services) where T : class
        {
            return services.GetService<T>();
        }
    }
}
