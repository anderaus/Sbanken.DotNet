using Sbanken.DotNet.Helpers;
using Sbanken.DotNet.Http;
using Sbanken.DotNet.Models;
using Sbanken.DotNet.Models.Request;
using Sbanken.DotNet.Models.Response;
using Sbanken.DotNet.Models.Response.Bank;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Operations
{
    public class BankOperations : OperationsBase, IBankOperations
    {
        public BankOperations(IConnection connection) : base(connection) { }

        public async Task<PagedResult<Account>> GetAccounts(string customerId)
        {
            Ensure.NotNullOrEmpty(customerId, nameof(customerId));

            var accountsResult = await Connection.Get<ListResult<Account>>($"Bank/api/v1/Accounts/{customerId}");
            EnsureSuccessfulResult(accountsResult);
            return new PagedResult<Account>(accountsResult.Items, accountsResult.AvailableItems);
        }

        public async Task<Account> GetAccount(string customerId, string accountNumber)
        {
            Ensure.NotNullOrEmpty(customerId, nameof(customerId));
            Ensure.NotNullOrEmpty(accountNumber, nameof(accountNumber));

            var accountResult = await Connection.Get<ItemResult<Account>>($"Bank/api/v1/Accounts/{customerId}/{accountNumber}");
            EnsureSuccessfulResult(accountResult);
            return accountResult.Item;
        }

        public async Task<PagedResult<Transaction>> GetTransactions(string customerId, string accountNumber,
            int index = 0, int length = 100, DateTime? startDate = null, DateTime? endDate = null)
        {
            Ensure.NotNullOrEmpty(customerId, nameof(customerId));
            Ensure.NotNullOrEmpty(accountNumber, nameof(accountNumber));

            var parameters = new Dictionary<string, string>
            {
                {"index", index.ToString()},
                {"length", length.ToString()}
            };

            if (startDate.HasValue) parameters.Add("startDate", startDate.Value.ToString("o"));
            if (endDate.HasValue) parameters.Add("endDate", endDate.Value.ToString("o"));

            var transactionsResult = await Connection.Get<ListResult<Transaction>>(
                $"Bank/api/v2/Transactions/{customerId}/{accountNumber}", parameters);

            EnsureSuccessfulResult(transactionsResult);
            return new PagedResult<Transaction>(transactionsResult.Items, transactionsResult.AvailableItems);
        }

        public async Task Transfer(string customerId, string fromAccount, string toAccount, decimal amount, string message)
        {
            Ensure.NotNullOrEmpty(customerId, nameof(customerId));
            Ensure.NotNullOrEmpty(fromAccount, nameof(fromAccount));
            Ensure.NotNullOrEmpty(toAccount, nameof(toAccount));
            Ensure.EqualOrGreaterThan(1, amount, nameof(amount));
            Ensure.NotNullOrEmpty(message, nameof(message));

            var transferRequestBody = new Transfer
            {
                FromAccount = fromAccount,
                ToAccount = toAccount,
                Amount = amount,
                Message = message
            };

            var transferResult = await Connection.Post(
                $"Bank/api/v1/Transfers/{customerId}", transferRequestBody);

            EnsureSuccessfulResult(transferResult);
        }
    }
}