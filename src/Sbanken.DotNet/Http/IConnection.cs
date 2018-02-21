using System;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Http
{
    public interface IConnection : IDisposable
    {
        Task<T> Get<T>(string relativeUrl);
    }
}