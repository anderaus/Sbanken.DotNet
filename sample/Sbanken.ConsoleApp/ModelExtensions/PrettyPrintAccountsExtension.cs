using Sbanken.DotNet.Models.Bank;
using System;
using System.Collections.Generic;

namespace Sbanken.ConsoleApp.ModelExtensions
{
    public static class PrettyPrintAccountsExtension
    {
        public static void PrettyPrint(this IEnumerable<Account> accounts, bool censorCustomerId = true)
        {
            Console.WriteLine("Accounts");
            foreach (var account in accounts)
            {
                Console.WriteLine($"  \"{account.Name}\"");
                Console.WriteLine($"    AccountNumber:    {account.AccountNumber}");
                Console.WriteLine($"    CustomerId:       {(censorCustomerId ? "xxxxxxxxxxx" : account.CustomerId)}");
                Console.WriteLine($"    OwnerCustomerId:  {(censorCustomerId ? "xxxxxxxxxxx" : account.OwnerCustomerId)}");
                Console.WriteLine($"    AccountType:      {account.AccountType}");
                Console.WriteLine($"    Balance:          {account.Balance}");
                Console.WriteLine($"    Available:        {account.Available}");
                Console.WriteLine($"    CreditLimit:      {account.CreditLimit}");
                Console.WriteLine($"    DefaultAccount:   {account.DefaultAccount}");
            }
        }
    }
}