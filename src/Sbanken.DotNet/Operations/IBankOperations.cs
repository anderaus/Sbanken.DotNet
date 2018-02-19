using Sbanken.DotNet.Models.Bank;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Operations
{
    public interface IBankOperations
    {
        Task<IEnumerable<Account>> GetAccounts(string customerId);
        Task<Account> GetAccount(string customerId, string accountNumber);
    }
}