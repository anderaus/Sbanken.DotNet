using Sbanken.DotNet.Models.Bank;
using System;

namespace Sbanken.ConsoleApp.ModelExtensions
{
    public static class PrettyPrintTransactionExtension
    {
        public static void PrettyPrint(this Transaction transaction)
        {
            Console.WriteLine("  Transaction");
            Console.WriteLine($"    From:             {transaction.AccountNumber}");
            Console.WriteLine($"    To:               {transaction.OtherAccountNumber}");
            Console.WriteLine($"    Amount:           {transaction.Amount}");
        }
    }
}