using Sbanken.DotNet.Exceptions;
using Sbanken.DotNet.Http;
using Sbanken.DotNet.Models.Response;

namespace Sbanken.DotNet.Operations
{
    public abstract class OperationsBase
    {
        protected IConnection Connection { get; }

        protected OperationsBase(IConnection connection)
        {
            Connection = connection;
        }

        protected void EnsureSuccessfulResult(IResult result)
        {
            if (result.IsError)
            {
                throw new SbankenException(result.ErrorMessage, result.ErrorType);
            }
        }
    }
}