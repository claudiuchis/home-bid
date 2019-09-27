using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

        public static IWebHost MigrateDbContext<TContext>(this IWebHost webHost, Action<TContext, IServiceProvider> seeder) where TContext: DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                logger.LogInformation($"Migrating database associated with context {typeof(TContext).Name}");
                context.Database.Migrate();

                seeder(context, services);

                return webHost;
            }
        }
    }
}