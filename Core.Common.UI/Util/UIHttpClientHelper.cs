using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.UI.Util
{
    public static class UIHttpClientHelper
    {
        private static IHttpClientFactory _httpClientFactory;

        public static void InyectHttpClientHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public static async Task<Resultado> Get<Resultado>(string apiRestClient, string urlEndpoint, string jsonTokenPath = "data")
            where Resultado : class, new()
        {
            try
            {
                Resultado resultado = new();

                using (var httpClient = _httpClientFactory.CreateClient(apiRestClient))
                {
                    var requestGet = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"{httpClient.BaseAddress.OriginalString}{urlEndpoint}")
                    };

                    var configAsync = await httpClient.SendAsync(requestGet).ConfigureAwait(false);
                    var responseString = await configAsync.Content.ReadAsStringAsync().ConfigureAwait(false);
                    JObject jsonResult = JObject.Parse(responseString);

                    JToken result = jsonResult.SelectToken(jsonTokenPath);

                    resultado = result.ToObject<Resultado>();
                }
                return resultado;

            }
            catch (HttpRequestException ex)
            {
                return null;
            }
        }

        public static async Task<Resultado> Put<Resultado>(string apiRestClient, string urlEndpoint, string jsonTokenPath = "data")
            where Resultado : class, new()
        {
            try
            {
                Resultado resultado = new();

                using (var httpClient = _httpClientFactory.CreateClient(apiRestClient))
                {
                    var requestGet = new HttpRequestMessage
                    {
                        Method = HttpMethod.Put,
                        RequestUri = new Uri($"{httpClient.BaseAddress.OriginalString}{urlEndpoint}")
                    };

                    var configAsync = await httpClient.SendAsync(requestGet).ConfigureAwait(false);
                    var responseString = await configAsync.Content.ReadAsStringAsync().ConfigureAwait(false);
                    JObject jsonResult = JObject.Parse(responseString);

                    JToken result = jsonResult.SelectToken(jsonTokenPath);

                    resultado = result.ToObject<Resultado>();
                }
                return resultado;

            }
            catch (HttpRequestException ex)
            {
                return null;
            }
        }

        public static async Task<Resultado> Put<Resultado>(string apiRestClient, string urlEndpoint, dynamic body, string jsonTokenPath = "data")
            where Resultado : class, new()
        {
            try
            {
                Resultado resultado = new();
                var json = JsonConvert.SerializeObject(body);

                using (var httpClient = _httpClientFactory.CreateClient(apiRestClient))
                {
                    var requestGet = new HttpRequestMessage
                    {
                        Method = HttpMethod.Put,
                        RequestUri = new Uri($"{httpClient.BaseAddress.OriginalString}{urlEndpoint}"),
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };

                    var configAsync = await httpClient.SendAsync(requestGet).ConfigureAwait(false);
                    var responseString = await configAsync.Content.ReadAsStringAsync().ConfigureAwait(false);
                    JObject jsonResult = JObject.Parse(responseString);

                    JToken result = jsonResult.SelectToken(jsonTokenPath);

                    resultado = result.ToObject<Resultado>();
                }
                return resultado;

            }
            catch (HttpRequestException ex)
            {
                return null;
            }
        }

        public static async Task<Resultado> Post<Resultado>(string apiRestClient, string urlEndpoint, string body, string jsonTokenPath = "data")
            where Resultado : class, new()
        {
            try
            {
                Resultado resultado = new();

                using (var httpClient = _httpClientFactory.CreateClient(apiRestClient))
                {
                    var requestGet = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri($"{httpClient.BaseAddress.OriginalString}{urlEndpoint}"),
                        Content = new StringContent($"\"{body}\"", Encoding.UTF8, "application/json")
                    };

                    var configAsync = await httpClient.SendAsync(requestGet).ConfigureAwait(false);
                    var responseString = await configAsync.Content.ReadAsStringAsync().ConfigureAwait(false);
                    JObject jsonResult = JObject.Parse(responseString);

                    JToken result = jsonResult.SelectToken(jsonTokenPath);

                    resultado = result.ToObject<Resultado>();
                }
                return resultado;

            }
            catch (HttpRequestException ex)
            {
                return null;
            }
        }

        public static async Task<Resultado> Post<Resultado>(string apiRestClient, string urlEndpoint, dynamic body, string jsonTokenPath = "data")
            where Resultado : class, new()
        {
            try
            {
                Resultado resultado = new();

                var json = JsonConvert.SerializeObject(body);

                using (var httpClient = _httpClientFactory.CreateClient(apiRestClient))
                {
                    var requestGet = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri($"{httpClient.BaseAddress.OriginalString}{urlEndpoint}"),
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };

                    var configAsync = await httpClient.SendAsync(requestGet).ConfigureAwait(false);
                    var responseString = await configAsync.Content.ReadAsStringAsync().ConfigureAwait(false);
                    JObject jsonResult = JObject.Parse(responseString);

                    JToken result = jsonResult.SelectToken(jsonTokenPath);

                    resultado = result.ToObject<Resultado>();
                }
                return resultado;
            }
            catch (HttpRequestException ex)
            {
                return null;
            }
        }
    }
}
