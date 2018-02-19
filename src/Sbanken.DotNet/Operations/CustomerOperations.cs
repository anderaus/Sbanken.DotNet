using Sbanken.DotNet.Exceptions;
using Sbanken.DotNet.Models;
using Sbanken.DotNet.Models.Customers;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Operations
{
    internal class CustomerOperations : ICustomerOperations
    {
        private readonly SbankenClient _client;

        public CustomerOperations(SbankenClient client)
        {
            _client = client;
        }

        public async Task<Customer> Get(string customerId)
        {
            var customerResult = await _client.Get<ItemResult<Customer>>($"Customers/api/v1/Customers/{customerId}");
            if (customerResult.IsError)
            {
                throw new SbankenException(customerResult.ErrorMessage, customerResult.ErrorType);
            }
            return customerResult.Item;
        }
    }
}