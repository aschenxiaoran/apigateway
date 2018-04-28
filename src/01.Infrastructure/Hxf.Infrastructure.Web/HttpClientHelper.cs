using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hxf.Infrastructure.Paging;
using Hxf.Infrastructure.Validation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Hxf.Infrastructure.Web {
    public static class HxfHttpClient {
        public static HttpClient HttpClient { get; } = new HttpClient();

        public static async Task<T> GetAsync<T>(HttpContext context, string url) {
            SetAuthorizationHeader(context);
            var json = await HttpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task<T> PostAsJsonAsync<T>(HttpContext context, string url, object value) {
            SetAuthorizationHeader(context);
            var requestJson = JsonConvert.SerializeObject(value);
            var requestContent = new StringContent(requestJson);
            requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var resPonse = await HttpClient.PostAsync(url, requestContent);
            var responseJson = await resPonse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseJson);
        }

        public static async Task<T> PostAsync<T>(HttpContext context, string url, List<KeyValuePair<string, string>> value) {
            SetAuthorizationHeader(context);
            var requestContent = new FormUrlEncodedContent(value);
            var resPonse = await HttpClient.PostAsync(url, requestContent);
            var responseJson = await resPonse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseJson);
        }

        private static void SetAuthorizationHeader(HttpContext context) {
            var tokenString = context.Request.Headers[HttpRequestHeader.Authorization.ToString()][0];
            var token = new Regex(@"^([^\s]+)\s+([^\s]+)").Match(tokenString).Groups[2].Value;
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}