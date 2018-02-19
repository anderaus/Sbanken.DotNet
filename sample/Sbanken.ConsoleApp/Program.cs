using Microsoft.Extensions.Configuration;
using Sbanken.ConsoleApp.ModelExtensions;
using Sbanken.DotNet;
using System.IO;
using System.Threading.Tasks;

namespace Sbanken.ConsoleApp
{
    class Program
    {
        private static AppSettings AppSettings { get; set; }

        static async Task Main(string[] args)
        {
            ReadConfiguration();

            await RunExample();
        }

        private static async Task RunExample()
        {
            using (var client = new SbankenClient(AppSettings.ClientId, AppSettings.ClientSecret))
            {
                var customer = await client.Customers.Get(AppSettings.CustomerId);
                customer.PrettyPrint();
            }
        }

        private static void ReadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            AppSettings = new AppSettings
            {
                ClientId = config.GetSection("clientId").Value,
                ClientSecret = config.GetSection("clientSecret").Value,
                CustomerId = config.GetSection("customerId").Value
            };
        }
    }
}