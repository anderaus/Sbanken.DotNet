using Sbanken.DotNet.Models;
using Sbanken.DotNet.Models.Response.Bank;
using System;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Operations
{
    public interface IBankOperations
    {
        Task<PagedResult<Account>> GetAccounts(string customerId);
        Task<Account> GetAccount(string customerId, string accountNumber);
        Task<PagedResult<Transaction>> GetTransactions(string customerId, string accountNumber,
            int index = 0, int length = 100, DateTime? startDate = null, DateTime? endDate = null);
        Task Transfer(string customerId, string fromAccount, string toAccount, decimal amount, string message);
    }
}