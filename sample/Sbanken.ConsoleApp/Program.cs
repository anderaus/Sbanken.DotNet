using Microsoft.Extensions.Configuration;
using Sbanken.DotNet;
using System.IO;
using System.Threading.Tasks;

namespace Sbanken.ConsoleApp
{
    class Program
    {
        private static AppSettings _appSettings { get; set; }

        static void Main(string[] args)
        {
            ReadConfiguration();

            RunExample().GetAwaiter().GetResult();
        }

        private static async Task RunExample()
        {
            using (var client = new SbankenClient(_appSettings.ClientId, _appSettings.ClientSecret))
            {
                var customer = await client.Customers.Get(_appSettings.CustomerId);
                customer.PrettyPrint();
            }
        }

        private static void ReadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            _appSettings = new AppSettings
            {
                ClientId = config.GetSection("clientId").Value,
                ClientSecret = config.GetSection("clientSecret").Value,
                CustomerId = config.GetSection("customerId").Value
            };
        }
    }
}