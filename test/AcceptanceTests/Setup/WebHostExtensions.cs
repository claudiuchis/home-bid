using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace HomeBid.Specifications.Setup
{
    public static class IWebHostExtensions
    {
        public static IWebHost UpdateDatabase<TContext>(this IWebHost webHost, Action<TContext> func)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();
                func(context);
            }
            return webHost;
        }
    }
}