using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Hxf.Infrastructure.ApiGateway.Repositories
{
    public class HttpDataRepository : IHttpDataRepository {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpDataRepository(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Add<T>(string key, T value) {
            _httpContextAccessor.HttpContext.Items.Add(key, value);
            await Task.FromResult(true);
        }

        public  T Get<T>(string key) {
            if (_httpContextAccessor.HttpContext == null || _httpContextAccessor.HttpContext.Items == null)
            {
                return  default(T);
            }

            if (_httpContextAccessor.HttpContext.Items.TryGetValue(key, out object obj)) {
                var data = (T)obj;
                return data;
            }

            return default(T);

        }

        public async Task<T> GetAsync<T>(string key) {
            if (_httpContextAccessor.HttpContext == null || _httpContextAccessor.HttpContext.Items == null)
            {
                return await Task.FromResult(default(T));
            }

            if (_httpContextAccessor.HttpContext.Items.TryGetValue(key, out object obj)) {
                var data = (T)obj;
                return await Task.FromResult(data);
            }

            return await Task.FromResult(default(T));

        }

    }
}