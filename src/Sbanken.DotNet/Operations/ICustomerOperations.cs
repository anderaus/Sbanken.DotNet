using Sbanken.DotNet.Models.Customers;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Operations
{
    public interface ICustomerOperations
    {
        Task<Customer> Get(string customerId);
    }
}