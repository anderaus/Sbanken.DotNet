using FakeItEasy;
using Sbanken.DotNet.Exceptions;
using Sbanken.DotNet.Http;
using Sbanken.DotNet.Models.Response;
using Sbanken.DotNet.Models.Response.Customers;
using Sbanken.DotNet.Operations;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sbanken.DotNet.Tests
{
    public class CustomerOperationsTests
    {
        private readonly CustomerOperations _customerOperations;
        private readonly IConnection _connection;

        public CustomerOperationsTests()
        {
            _connection = A.Fake<IConnection>();
            _customerOperations = new CustomerOperations(_connection);
        }

        [Fact]
        public async Task Get_WhenCustomerIdIsNull_ShouldThrowArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _customerOperations.Get(null));
        }

        [Fact]
        public async Task Get_WhenCustomerIdIsEmpty_ShouldThrowArgumentException()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _customerOperations.Get(""));
        }

        [Fact]
        public async Task Get_WhenResultIsUnsuccessful_ShouldThrowSbankenException()
        {
            A.CallTo(() => _connection.Get<ItemResult<Customer>>(A<string>._, null)).Returns(new ItemResult<Customer>
            {
                IsError = true,
                ErrorMessage = "Something went very wrong",
                ErrorType = "TheErrorType"
            }
            );

            var exception = await Assert.ThrowsAsync<SbankenException>(() => _customerOperations.Get("12037649749"));

            Assert.Equal("Something went very wrong, ErrorType: TheErrorType", exception.Message);
        }

        [Fact]
        public async Task Get_WhenResultIsSuccessful_ShouldReturnCustomer()
        {
            A.CallTo(() => _connection.Get<ItemResult<Customer>>(A<string>._, null)).Returns(new ItemResult<Customer>
            {
                IsError = false,
                Item = new Customer
                {
                    FirstName = "Roger",
                    LastName = "Wilco"
                }
            }
            );

            var result = await _customerOperations.Get("12037649749");

            A.CallTo(() => _connection.Get<ItemResult<Customer>>("Customers/api/v1/Customers/12037649749", null)).MustHaveHappenedOnceExactly();

            Assert.Equal("Roger", result.FirstName);
            Assert.Equal("Wilco", result.LastName);
        }
    }
}