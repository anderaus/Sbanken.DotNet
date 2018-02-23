using Sbanken.DotNet.Models.Response.Bank;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Operations
{
    public interface IBankOperations
    {
        Task<IReadOnlyList<Account>> GetAccounts(string customerId);
        Task<Account> GetAccount(string customerId, string accountNumber);
        Task<IReadOnlyList<Transaction>> GetTransactions(string customerId, string accountNumber,
            int index = 0, int length = 100, DateTime? startDate = null, DateTime? endDate = null);
    }
}