using Microsoft.Extensions.Logging;
using MonthlyFollowUp.Implementations;
using Orleans.Configuration;
using Orleans.Hosting;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MonthlyFollowUp.MiddleTier
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var t = typeof(UserRegistryGrain);
                Console.WriteLine(t);
                var host = await StartSilo();
                Console.WriteLine("Press Enter to terminate...");
                Console.ReadLine();

                await host.StopAsync();

                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }

        private static async Task<ISiloHost> StartSilo()
        {
            //var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=orlean;Integrated Security=True;";

            var builder = new SiloHostBuilder()
                // Use localhost clustering for a single local silo
                .UseLocalhostClustering()
                // Configure ClusterId and ServiceId
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "MyAwesomeService";
                }).AddMemoryGrainStorage("memory")
            //.AddAdoNetGrainStorage("ado", options =>
            //    {
            //        options.Invariant = "System.Data.SqlClient";
            //        options.ConnectionString = connectionString;
            //    })
            // Configure connectivity
            .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback)
                // Configure logging with any logging framework that supports Microsoft.Extensions.Logging.
                // In this particular case it logs using the Microsoft.Extensions.Logging.Console package.
                .ConfigureLogging(logging => logging.AddConsole());

            var host = builder.Build();
            await host.StartAsync();
            return host;
        }
    }
}
