using FakeItEasy;
using Sbanken.DotNet.Exceptions;
using Sbanken.DotNet.Http;
using Sbanken.DotNet.Models.Response;
using Sbanken.DotNet.Models.Response.Bank;
using Sbanken.DotNet.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sbanken.DotNet.Tests
{
    public class BankOperationsTests
    {
        private readonly BankOperations _bankOperations;
        private readonly IConnection _connection;

        public BankOperationsTests()
        {
            _connection = A.Fake<IConnection>();
            _bankOperations = new BankOperations(_connection);
        }

        [Fact]
        public async Task GetAccounts_WhenCustomerIdIsNull_ShouldThrowArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _bankOperations.GetAccounts(null));
        }

        [Fact]
        public async Task GetAccounts_WhenCustomerIdIsEmpty_ShouldThrowArgumentException()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _bankOperations.GetAccounts(""));
        }

        [Fact]
        public async Task GetAccounts_WhenResultIsUnsuccessful_ShouldThrowSbankenException()
        {
            A.CallTo(() => _connection.Get<ListResult<Account>>(A<string>._, null)).Returns(new ListResult<Account>
            {
                IsError = true,
                ErrorMessage = "Something went very wrong",
                ErrorType = "TheErrorType"
            }
            );

            var exception = await Assert.ThrowsAsync<SbankenException>(() => _bankOperations.GetAccounts("12037649749"));

            Assert.Equal("Something went very wrong, ErrorType: TheErrorType", exception.Message);
        }

        [Fact]
        public async Task GetAccounts_WhenResultIsSuccessful_ShouldReturnAccounts()
        {
            A.CallTo(() => _connection.Get<ListResult<Account>>(A<string>._, null)).Returns(new ListResult<Account>
            {
                IsError = false,
                AvailableItems = 2,
                Items = new List<Account>
                {
                    new Account
                    {
                        Name = "Savings"
                    },
                    new Account
                    {
                        Name = "Salary"
                    }
                }
            }
            );

            var result = await _bankOperations.GetAccounts("12037649749");

            A.CallTo(() => _connection.Get<ListResult<Account>>("Bank/api/v1/Accounts/12037649749", null)).MustHaveHappenedOnceExactly();

            Assert.Equal(2, result.AvailableItems);
            Assert.Equal(2, result.Items.Count);
            Assert.Equal("Savings", result.Items.First().Name);
            Assert.Equal("Salary", result.Items.Last().Name);
        }

        [Fact]
        public async Task GetAccount_WhenCustomerIdIsNull_ShouldThrowArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _bankOperations.GetAccount(null, "accountNumber"));
        }

        [Fact]
        public async Task GetAccount_WhenCustomerIdIsEmpty_ShouldThrowArgumentException()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _bankOperations.GetAccount("", "accountNumber"));
        }

        [Fact]
        public async Task GetAccount_WhenAccountNumberIsNull_ShouldThrowArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _bankOperations.GetAccount("customerId", null));
        }

        [Fact]
        public async Task GetAccount_WhenAccountNumberIsEmpty_ShouldThrowArgumentException()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _bankOperations.GetAccount("customerId", ""));
        }

        [Fact]
        public async Task GetAccount_WhenResultIsUnsuccessful_ShouldThrowSbankenException()
        {
            A.CallTo(() => _connection.Get<ItemResult<Account>>(A<string>._, null)).Returns(new ItemResult<Account>
            {
                IsError = true,
                ErrorMessage = "Something went very wrong",
                ErrorType = "TheErrorType"
            }
            );

            var exception = await Assert.ThrowsAsync<SbankenException>(() => _bankOperations.GetAccount("12037649749", "12341212345"));

            Assert.Equal("Something went very wrong, ErrorType: TheErrorType", exception.Message);
        }

        [Fact]
        public async Task GetAccount_WhenResultIsSuccessful_ShouldReturnAccount()
        {
            A.CallTo(() => _connection.Get<ItemResult<Account>>(A<string>._, null)).Returns(new ItemResult<Account>
            {
                IsError = false,
                Item = new Account
                {
                    Name = "Savings"
                }
            }
            );

            var result = await _bankOperations.GetAccount("12037649749", "12341212345");

            A.CallTo(() => _connection.Get<ItemResult<Account>>("Bank/api/v1/Accounts/12037649749/12341212345", null)).MustHaveHappenedOnceExactly();

            Assert.NotNull(result);
            Assert.Equal("Savings", result.Name);
        }
    }
}