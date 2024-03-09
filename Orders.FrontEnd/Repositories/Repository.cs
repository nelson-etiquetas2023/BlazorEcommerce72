﻿using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Net.Http;

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

        public async Task<HttpResponseWrapper<T>> GetAsync<T>(string url)
        {
            var httpResponse = await _httpClient.GetAsync(url);

            if (httpResponse.IsSuccessStatusCode) 
            {
                var response = await UnserializeAnswer<T>(httpResponse);
                return new HttpResponseWrapper<T>(response, false, httpResponse);
            }

            return new HttpResponseWrapper<T>(default, true, httpResponse);

        }

        public async Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model)
        {
            var messageJSON = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(messageJSON, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync(url, messageContent);
            return new HttpResponseWrapper<object>(null, !httpResponse.IsSuccessStatusCode, httpResponse);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T model)
        {
            var messageJSON = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(messageJSON, Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.PostAsync(url, messageContent);
            if (httpResponse.IsSuccessStatusCode) 
            {
                var response = await UnserializeAnswer<TActionResponse>(httpResponse);
                return new HttpResponseWrapper<TActionResponse>(response, false, httpResponse);
            }

            return new HttpResponseWrapper<TActionResponse>(default,!httpResponse.IsSuccessStatusCode,httpResponse);
        }

        private async Task<T> UnserializeAnswer<T>(HttpResponseMessage httpResponse)
        {
            var response = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(response, _jsonDefaultOptions)!;
        }

    }
}
