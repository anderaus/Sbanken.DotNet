using Sbanken.DotNet.Models;
using System;
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
            var customerResult = await _client.Get<CustomerResult>($"Customers/api/v1/Customers/{customerId}");
            if (customerResult.IsError) throw new NotImplementedException();
            return customerResult.Item;
        }
    }
}