using Sbanken.DotNet.Models.Response.Customers;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Operations
{
    public interface ICustomerOperations
    {
        Task<Customer> Get(string customerId);
    }
}