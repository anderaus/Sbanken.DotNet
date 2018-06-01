# Sbanken.DotNet

[![Build status](https://ci.appveyor.com/api/projects/status/drouf5rqk0mgjjv6?svg=true)](https://ci.appveyor.com/project/anderaus/sbanken-dotnet)
[![Test stats](https://img.shields.io/appveyor/tests/anderaus/sbanken-dotnet.svg)](https://ci.appveyor.com/project/anderaus/sbanken-dotnet/build/tests)
[![NuGet](https://img.shields.io/nuget/v/Sbanken.DotNet.svg)](https://www.nuget.org/packages/Sbanken.DotNet/)

Unofficial .NET (C#) client library for Sbanken API

## What is Sbanken.DotNet?

Sbanken.DotNet is a lightweight C# wrapper for the Sbanken API endpoints:

> https://api.sbanken.no/Bank/swagger   
> https://api.sbanken.no/Customers/swagger

### Features
- Automatic access token renewal
- Supports >= .NET Standard 1.4

## Usage

Install latest package from nuget using the package manager

```
Install-Package Sbanken.DotNet
```

or the .NET CLI
```
dotnet add package Sbanken.DotNet
```


Register at https://sbanken.no/bruke/utviklerportalen to get `CLIENT_ID` and `SECRET`. The `CUSTOMER_ID` is your SSN (fødselsnummer).

```cs
using Sbanken.DotNet;

using (var client = new SbankenClient(CLIENT_ID, SECRET)) {
    
    // Fetch customer metadata
    var customer = await client.Customers.Get(CUSTOMER_ID);

    // Fetch all bank accounts and balances
    var accounts = await client.Bank.GetAccounts(CUSTOMER_ID);

    // Loop accounts and print balance
    foreach (var account in accounts) {
        Console.WriteLine(
            $"Got account {account.Name} with balance {account.Balance});
    }

    // Transfer amount (399 NOK) between accounts
    await client.Bank.Transfer(
        CUSTOMER_ID,
        FROM_ACCOUNT_ID,
        TO_ACCOUT_ID,
        399.0m,
        "More U save, more U earn");
}
```

Currently, the Sbanken API only supports operations on accounts you own.

## Links
- [Nuget package](https://www.nuget.org/packages/Sbanken.DotNet/)
- [Sbanken developer portal](https://sbanken.no/bruke/utviklerportalen/)
- [A first look at the SBanken Open Banking API](http://blog.novanet.no/a-first-look-at-the-sbanken-open-banking-api/)
