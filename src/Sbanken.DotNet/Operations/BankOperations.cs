using Sbanken.DotNet.Exceptions;
using Sbanken.DotNet.Models;
using Sbanken.DotNet.Models.Bank;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Operations
{
    public class BankOperations : IBankOperations
    {
        private readonly SbankenClient _client;

        public BankOperations(SbankenClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Account>> GetAccounts(string customerId)
        {
            var accountsResult = await _client.Get<ListResult<Account>>($"Bank/api/v1/Accounts/{customerId}");
            if (accountsResult.IsError)
            {
                throw new SbankenException(accountsResult.ErrorMessage, accountsResult.ErrorType);
            }
            return accountsResult.Items;
        }

        public async Task<Account> GetAccount(string customerId, string accountNumber)
        {
            var accountResult = await _client.Get<ItemResult<Account>>($"Bank/api/v1/Accounts/{customerId}/{accountNumber}");
            if (accountResult.IsError)
            {
                throw new SbankenException(accountResult.ErrorMessage, accountResult.ErrorType);
            }

            return accountResult.Item;
        }
    }
}