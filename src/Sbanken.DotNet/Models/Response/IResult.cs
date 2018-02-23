namespace Sbanken.DotNet.Models.Response
{
    public interface IResult
    {
        string ErrorType { get; }
        bool IsError { get; }
        string ErrorMessage { get; }
        string TraceId { get; }
    }
}