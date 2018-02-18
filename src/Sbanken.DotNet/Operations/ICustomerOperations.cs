using Sbanken.DotNet.Models;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Operations
{
    public interface ICustomerOperations
    {
        Task<Customer> Get(string customerId);
    }
}