using Sbanken.DotNet.Exceptions;
using Xunit;

namespace Sbanken.DotNet.Tests
{
    public class SbankenExceptionTests
    {
        [Fact]
        public void ToStringOutputsMessage()
        {
            var exception = new SbankenException("This is the message");

            var output = exception.ToString();

            Assert.Equal("Sbanken.DotNet.Exceptions.SbankenException: This is the message", output);
        }

        [Fact]
        public void ToStringOutputsErrorType()
        {
            var exception = new SbankenException("This is the message", "This is the errortype");

            var output = exception.ToString();

            Assert.Equal("Sbanken.DotNet.Exceptions.SbankenException: This is the message, ErrorType: This is the errortype", output);
        }
    }
}