using Sbanken.DotNet.Models.Response.Bank;
using System;

namespace Sbanken.ConsoleApp.ModelExtensions
{
    public static class PrettyPrintTransactionExtension
    {
        public static void PrettyPrint(this Transaction transaction)
        {
            Console.WriteLine("  Transaction");
            Console.WriteLine($"    TransactionId:      {transaction.TransactionId}");
            Console.WriteLine($"    AccountingDate:     {transaction.AccountingDate}");
            Console.WriteLine($"    RegistrationDate:   {transaction.RegistrationDate}");
            Console.WriteLine($"    InterestDate:       {transaction.InterestDate}");
            Console.WriteLine($"    From:               {transaction.AccountNumber}");
            Console.WriteLine($"    To:                 {transaction.OtherAccountNumber}");
            Console.WriteLine($"    Amount:             {transaction.Amount}");
            Console.WriteLine($"    TransactionType:    {transaction.TransactionType}");
            Console.WriteLine($"    Text:               {transaction.Text}");
        }
    }
}