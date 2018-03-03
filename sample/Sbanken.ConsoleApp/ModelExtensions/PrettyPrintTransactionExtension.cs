using Sbanken.DotNet.Models.Response.Bank;
using System;

namespace Sbanken.ConsoleApp.ModelExtensions
{
    public static class PrettyPrintTransactionExtension
    {
        public static void PrettyPrint(this Transaction transaction)
        {
            Console.WriteLine("  Transaction");
            Console.WriteLine($"    AccountingDate:        {transaction.AccountingDate}");
            Console.WriteLine($"    InterestDate:          {transaction.InterestDate}");
            Console.WriteLine($"    To:                    {transaction.OtherAccountNumber}");
            Console.WriteLine($"    Amount:                {transaction.Amount}");
            Console.WriteLine($"    TransactionType:       {transaction.TransactionType}");
            Console.WriteLine($"    TransactionTypeCode:   {transaction.TransactionTypeCode}");
            Console.WriteLine($"    TransactionTypeText:   {transaction.TransactionTypeText}");
            Console.WriteLine($"    Text:                  {transaction.Text}");
            Console.WriteLine($"    IsReservation:         {transaction.IsReservation}");
            Console.WriteLine($"    ReservationType:       {transaction.ReservationType}");
            Console.WriteLine($"    Source:                {transaction.Source}");
            Console.WriteLine($"    CardDetailsSpecified:  {transaction.CardDetailsSpecified}");

            if (transaction.CardDetails != null)
            {
                Console.WriteLine("    Card details");
                Console.WriteLine($"      CardNumber:                   {transaction.CardDetails.CardNumber}");
                Console.WriteLine($"      CurrencyAmount:               {transaction.CardDetails.CurrencyAmount}");
                Console.WriteLine($"      CurrencyRate:                 {transaction.CardDetails.CurrencyRate}");
                Console.WriteLine($"      MerchantCategoryCode:         {transaction.CardDetails.MerchantCategoryCode}");
                Console.WriteLine($"      MerchantCategoryDescription:  {transaction.CardDetails.MerchantCategoryDescription}");
                Console.WriteLine($"      MerchantCity:                 {transaction.CardDetails.MerchantCity}");
                Console.WriteLine($"      MerchantName:                 {transaction.CardDetails.MerchantName}");
                Console.WriteLine($"      OriginalCurrencyCode:         {transaction.CardDetails.OriginalCurrencyCode}");
                Console.WriteLine($"      PurchaseDate:                 {transaction.CardDetails.PurchaseDate}");
                Console.WriteLine($"      TransactionId:                {transaction.CardDetails.TransactionId}");
            }
        }
    }
}