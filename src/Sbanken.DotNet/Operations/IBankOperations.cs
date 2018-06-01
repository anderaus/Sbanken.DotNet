using Sbanken.DotNet.Models;
using Sbanken.DotNet.Models.Response.Bank;
using System;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Operations
{
    public interface IBankOperations
    {
        Task<PagedResult<Account>> GetAccounts(string customerId);
        Task<Account> GetAccount(string customerId, string accountId);
        Task<PagedResult<Transaction>> GetTransactions(string customerId, string accountId,
            int index = 0, int length = 100, DateTime? startDate = null, DateTime? endDate = null);
        Task Transfer(string customerId, string fromAccountId, string toAccountId, decimal amount, string message);
    }
}