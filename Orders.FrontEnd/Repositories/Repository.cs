using System.Text;
using System.Text.Json;

namespace Orders.FrontEnd.Repositories
{
    public class Repository : IRepository
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _jsonDefaultOptions => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public Repository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public Task<HttpResponseWrapper<T>> GetAsync<T>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T model)
        {
            throw new NotImplementedException();
        }
    }
}
