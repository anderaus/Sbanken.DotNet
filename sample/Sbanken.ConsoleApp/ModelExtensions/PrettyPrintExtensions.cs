using Sbanken.DotNet.Models;
using System;

namespace Sbanken.ConsoleApp.ModelExtensions
{
    public static class PrettyPrintExtensions
    {
        public static void PrettyPrint(this Customer customer, bool censorCustomerId = true)
        {
            Console.WriteLine("Customer");
            Console.WriteLine($"  CustomerId:       {(censorCustomerId ? "xxxxxxxxxxx" : customer.CustomerId)}");
            Console.WriteLine($"  First name:       {customer.FirstName}");
            Console.WriteLine($"  Last name:        {customer.LastName}");
            Console.WriteLine($"  Date of birth:    {customer.DateOfBirth}");
            Console.WriteLine($"  Email:            {customer.EmailAddress}");

            if (customer.PostalAddress != null)
            {
                Console.WriteLine("  Postal address");
                Console.WriteLine($"    Line 1:         {customer.PostalAddress.AddressLine1}");
                Console.WriteLine($"    Line 2:         {customer.PostalAddress.AddressLine2}");
                Console.WriteLine($"    Line 3:         {customer.PostalAddress.AddressLine3}");
                Console.WriteLine($"    Line 4:         {customer.PostalAddress.AddressLine4}");
                Console.WriteLine($"    Zipcode:        {customer.PostalAddress.ZipCode}");
                Console.WriteLine($"    City:           {customer.PostalAddress.City}");
                Console.WriteLine($"    Country:        {customer.PostalAddress.Country}");
            }

            if (customer.StreetAddress != null)
            {
                Console.WriteLine("  Street address");
                Console.WriteLine($"    Line 1:         {customer.StreetAddress.AddressLine1}");
                Console.WriteLine($"    Line 2:         {customer.StreetAddress.AddressLine2}");
                Console.WriteLine($"    Line 3:         {customer.StreetAddress.AddressLine3}");
                Console.WriteLine($"    Line 4:         {customer.StreetAddress.AddressLine4}");
                Console.WriteLine($"    Zipcode:        {customer.StreetAddress.ZipCode}");
                Console.WriteLine($"    City:           {customer.StreetAddress.City}");
                Console.WriteLine($"    Country:        {customer.StreetAddress.Country}");
            }

            foreach (var number in customer.PhoneNumbers)
            {
                Console.WriteLine("  Phone number");
                Console.WriteLine($"    Country code:   {number.CountryCode}");
                Console.WriteLine($"    Number:         {number.Number}");
            }
        }
    }
}