using System;

namespace Sbanken.DotNet.Exceptions
{
    public class SbankenException : Exception
    {
        private readonly string _errorType;

        public SbankenException()
        {

        }

        public SbankenException(string message)
            : base(message)
        {

        }

        public SbankenException(string message, string errorType)
            : base(message)
        {
            _errorType = errorType;
        }

        public override string Message
        {
            get
            {
                var errorTypeMessage = string.IsNullOrEmpty(_errorType) ? "" : $", ErrorType: {_errorType}";
                return $"{base.Message}{errorTypeMessage}";
            }
        }
    }
}