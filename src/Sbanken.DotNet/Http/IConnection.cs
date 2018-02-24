using Sbanken.DotNet.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Http
{
    public interface IConnection : IDisposable
    {
        Task<T> Get<T>(string relativeUrl, IDictionary<string, string> parameters = null);
        Task<NoResult> Post(string relativeUrl, object body);
    }
}