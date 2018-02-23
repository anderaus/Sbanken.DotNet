using Newtonsoft.Json;

namespace Sbanken.DotNet.Models.Response
{
    public class ItemResult<T>
    {
        [JsonProperty("item")]
        public T Item { get; protected set; }

        [JsonProperty("errorType")]
        public string ErrorType { get; protected set; }

        [JsonProperty("isError")]
        public bool IsError { get; protected set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; protected set; }

        [JsonProperty("traceId")]
        public string TraceId { get; protected set; }
    }
}