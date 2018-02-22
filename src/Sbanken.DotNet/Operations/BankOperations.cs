using Sbanken.DotNet.Exceptions;
using Sbanken.DotNet.Http;
using Sbanken.DotNet.Models;
using Sbanken.DotNet.Models.Bank;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Operations
{
    public class BankOperations : IBankOperations
    {
        private readonly IConnection _connection;

        public BankOperations(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Account>> GetAccounts(string customerId)
        {
            var accountsResult = await _connection.Get<ListResult<Account>>($"Bank/api/v1/Accounts/{customerId}");
            if (accountsResult.IsError)
            {
                throw new SbankenException(accountsResult.ErrorMessage, accountsResult.ErrorType);
            }
            return accountsResult.Items;
        }

        public async Task<Account> GetAccount(string customerId, string accountNumber)
        {
            var accountResult = await _connection.Get<ItemResult<Account>>($"Bank/api/v1/Accounts/{customerId}/{accountNumber}");
            if (accountResult.IsError)
            {
                throw new SbankenException(accountResult.ErrorMessage, accountResult.ErrorType);
            }

            return accountResult.Item;
        }

        public async Task<IEnumerable<Transaction>> GetTransactions(string customerId, string accountNumber, int index, int length, DateTime startDate, DateTime endDate)
        {
            var transactionsResult = await _connection.Get<ListResult<Transaction>>(
                $"Bank/api/v1/Transactions/{customerId}/{accountNumber}",
                new Dictionary<string, string>
                {
                    {"index", index.ToString()},
                    {"length", length.ToString()},
                    {"startDate", startDate.ToString("o")},
                    {"endDate", endDate.ToString("o")}
                });

            if (transactionsResult.IsError)
            {
                throw new SbankenException(transactionsResult.ErrorMessage, transactionsResult.ErrorType);
            }

            return transactionsResult.Items;
        }
    }
}