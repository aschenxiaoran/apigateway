using System.Threading.Tasks;

namespace Hxf.Infrastructure.ApiGateway.Repositories
{
    internal interface IHttpDataRepository {
        Task Add<T>(string key, T value);

        T Get<T>(string key);

        Task<T> GetAsync<T>(string key);
    }
}