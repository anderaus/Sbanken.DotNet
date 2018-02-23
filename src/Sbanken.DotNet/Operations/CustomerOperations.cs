using Sbanken.DotNet.Exceptions;
using Sbanken.DotNet.Http;
using Sbanken.DotNet.Models.Response;
using Sbanken.DotNet.Models.Response.Customers;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Operations
{
    internal class CustomerOperations : ICustomerOperations
    {
        private readonly IConnection _connection;

        public CustomerOperations(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<Customer> Get(string customerId)
        {
            var customerResult = await _connection.Get<ItemResult<Customer>>($"Customers/api/v1/Customers/{customerId}");
            if (customerResult.IsError)
            {
                throw new SbankenException(customerResult.ErrorMessage, customerResult.ErrorType);
            }
            return customerResult.Item;
        }
    }
}