using Microsoft.Extensions.Configuration;
using Sbanken.ConsoleApp.ModelExtensions;
using Sbanken.DotNet;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sbanken.ConsoleApp
{
    class Program
    {
        private static AppSettings AppSettings { get; set; }

        static void Main(string[] args)
        {
            ReadConfiguration();

            RunExample().GetAwaiter().GetResult();
        }

        private static async Task RunExample()
        {
            using (var client = new SbankenClient(AppSettings.ClientId, AppSettings.ClientSecret))
            {
                var customer = await client.Customers.Get(AppSettings.CustomerId);
                customer.PrettyPrint();

                var accounts = await client.Bank.GetAccounts(AppSettings.CustomerId);
                Console.WriteLine("Accounts");
                foreach (var account in accounts)
                {
                    account.PrettyPrint();
                }

                var bestAccount =
                    await client.Bank.GetAccount(
                        AppSettings.CustomerId,
                        accounts.OrderByDescending(a => a.Balance).First().AccountNumber);
                Console.WriteLine("Refetched single account with highest balance");
                bestAccount.PrettyPrint();

                var transactions =
                    await client.Bank.GetTransactions(
                        AppSettings.CustomerId,
                        bestAccount.AccountNumber,
                        0,
                        5,
                        DateTime.UtcNow.AddDays(-30),
                        DateTime.UtcNow.AddDays(-5));
                foreach (var transaction in transactions)
                {
                    transaction.PrettyPrint();
                }
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