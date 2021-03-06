﻿using Microsoft.Extensions.Configuration;
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

        static async Task Main()
        {
            ReadConfiguration();

            await RunExample();
        }

        private static async Task RunExample()
        {
            using (var client = new SbankenClient(AppSettings.ClientId, AppSettings.ClientSecret))
            {
                // Get customer information
                var customer = await client.Customers.Get(AppSettings.CustomerId);
                customer.PrettyPrint();

                // Get all customer accounts
                var accounts = await client.Bank.GetAccounts(AppSettings.CustomerId);
                Console.WriteLine("Accounts");
                foreach (var account in accounts.Items)
                {
                    account.PrettyPrint();
                }

                var savingsAccountId = accounts.Items.Single(a => a.Name == "Hovedkonto").AccountId;
                var spendingAccountId = accounts.Items.Single(a => a.Name == "Visakonto").AccountId;

                // Get a single account
                var savingsAccount =
                    await client.Bank.GetAccount(AppSettings.CustomerId, savingsAccountId);
                Console.WriteLine($"{Environment.NewLine}Refetched savings account");
                savingsAccount.PrettyPrint();

                // Get a subset of transaction for one account
                var transactions =
                    await client.Bank.GetTransactions(
                        customerId: AppSettings.CustomerId,
                        accountId: spendingAccountId,
                        index: 0,
                        length: 20,
                        startDate: DateTime.UtcNow.AddDays(-90),
                        endDate: DateTime.UtcNow.AddDays(-5));
                Console.WriteLine($"{Environment.NewLine}Latest transactions for account {savingsAccountId}");
                foreach (var transaction in transactions.Items)
                {
                    transaction.PrettyPrint();
                }

                // Transfer 5 NOK from salary account to savings account
                await client.Bank.Transfer(
                    AppSettings.CustomerId,
                    savingsAccountId,
                    spendingAccountId,
                    5.0m,
                    "Testing Sbanken.DotNet");
                Console.WriteLine("Transferred 5 NOK ok!");
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