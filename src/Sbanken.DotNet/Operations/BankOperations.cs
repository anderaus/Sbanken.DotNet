using Sbanken.DotNet.Exceptions;
using Sbanken.DotNet.Http;
using Sbanken.DotNet.Models;
using Sbanken.DotNet.Models.Response;
using Sbanken.DotNet.Models.Response.Bank;
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

        public async Task<PagedResult<Account>> GetAccounts(string customerId)
        {
            var accountsResult = await _connection.Get<ListResult<Account>>($"Bank/api/v1/Accounts/{customerId}");
            if (accountsResult.IsError)
            {
                throw new SbankenException(accountsResult.ErrorMessage, accountsResult.ErrorType);
            }
            return new PagedResult<Account>(accountsResult.Items, accountsResult.AvailableItems);
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

        public async Task<PagedResult<Transaction>> GetTransactions(string customerId, string accountNumber,
            int index = 0, int length = 100, DateTime? startDate = null, DateTime? endDate = null)
        {
            var parameters = new Dictionary<string, string>
            {
                {"index", index.ToString()},
                {"length", length.ToString()}
            };

            if (startDate.HasValue) parameters.Add("startDate", startDate.Value.ToString("o"));
            if (endDate.HasValue) parameters.Add("endDate", endDate.Value.ToString("o"));

            var transactionsResult = await _connection.Get<ListResult<Transaction>>(
                $"Bank/api/v1/Transactions/{customerId}/{accountNumber}", parameters);

            if (transactionsResult.IsError)
            {
                throw new SbankenException(transactionsResult.ErrorMessage, transactionsResult.ErrorType);
            }

            return new PagedResult<Transaction>(transactionsResult.Items, transactionsResult.AvailableItems);
        }
    }
}