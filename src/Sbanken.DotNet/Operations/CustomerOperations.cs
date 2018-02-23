using Sbanken.DotNet.Helpers;
using Sbanken.DotNet.Http;
using Sbanken.DotNet.Models.Response;
using Sbanken.DotNet.Models.Response.Customers;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Operations
{
    public class CustomerOperations : OperationsBase, ICustomerOperations
    {
        public CustomerOperations(IConnection connection) : base(connection) { }

        public async Task<Customer> Get(string customerId)
        {
            Ensure.NotNullOrEmpty(customerId, nameof(customerId));

            var customerResult = await Connection.Get<ItemResult<Customer>>($"Customers/api/v1/Customers/{customerId}");
            EnsureSuccessfulResult(customerResult);
            return customerResult.Item;
        }
    }
}