using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using HomeBid.Services.Bidding;
using HomeBid.Services.Bidding.Infrastructure;

namespace HomeBid.Specifications.Setup
{
    public static class TestSetup
    {
        private static TestServer _testServer;
        public static TestServer TestServer
        {
            get {
                if (_testServer == null)
                {
                    var path = Assembly.GetAssembly(typeof(TestSetup)).Location;

                    var hostBuilder = new WebHostBuilder()
                        .UseContentRoot(Path.GetDirectoryName(path))
                        .ConfigureAppConfiguration(cb =>
                        {
                            cb.AddJsonFile("appsettings.json", optional: false)
                            .AddEnvironmentVariables();
                        })
                        .UseStartup<Startup>();

                    _testServer = new TestServer(hostBuilder);

                    _testServer.Host
                        .MigrateDbContext<BiddingContext>((context, services) => 
                        {

                        });
                }
                return _testServer;
            }
        }
    }
}
