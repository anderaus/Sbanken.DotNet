using Sbanken.DotNet.Http;
using Sbanken.DotNet.Operations;
using System;

namespace Sbanken.DotNet
{
    public class SbankenClient : IDisposable
    {
        private bool _disposed;

        private readonly IConnection _connection;

        public SbankenClient(string clientId, string clientSecret)
        {
            _connection = new Connection(clientId, clientSecret);

            Customers = new CustomerOperations(_connection);
            Bank = new BankOperations(_connection);
        }

        public ICustomerOperations Customers { get; }
        public IBankOperations Bank { get; }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _connection.Dispose();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}