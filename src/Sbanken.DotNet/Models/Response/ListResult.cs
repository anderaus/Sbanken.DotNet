using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sbanken.DotNet.Models.Response
{
    public class ListResult<T> : IResult
    {
        [JsonProperty("availableItems")]
        public int AvailableItems { get; protected set; }

        [JsonProperty("items")]
        public IReadOnlyList<T> Items { get; protected set; }

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