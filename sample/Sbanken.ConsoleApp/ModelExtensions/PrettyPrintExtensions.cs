using Sbanken.DotNet.Models;
using System;

public static class PrettyPrintExtensions
{
    public static void PrettyPrint(this Customer customer)
    {
        Console.WriteLine("*** Customer ***");
        Console.WriteLine($"First name:         {customer.FirstName}");
        Console.WriteLine($"Last name:          {customer.LastName}");
        Console.WriteLine($"Date of birth:      {customer.DateOfBirth}");
        Console.WriteLine($"Email:              {customer.EmailAddress}");
    }
}
