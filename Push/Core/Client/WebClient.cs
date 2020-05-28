using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Push.Core.Client
{
    public interface IWebClient
    {
        Task<Response> InvokePost(CancellationToken cancellationToken, string contentBody, string baseUrl,
            string requestUrl,
            string token = null);
    }

    public class WebClient : IWebClient
    {
        private readonly HttpClient _client;

        /// <summary>
        ///     Creates a new instance of the <see cref="WebClient" /> class
        /// </summary>
        /// <param name="client">Http Client</param>
        public WebClient(HttpClient client)
        {
            _client = client;
            _client.DefaultRequestHeaders.Clear();
        }

        /// <summary>
        ///     <see cref="IWebClient.InvokePost(CancellationToken,string,string,string,string)" />
        /// </summary>
        public async Task<Response> InvokePost(CancellationToken cancellationToken, string contentBody, string baseUrl,
            string requestUrl,
            string token = null)
        {
            Response responseClient = null;

            if (_client.BaseAddress == null) _client.BaseAddress = new Uri(baseUrl);


            if (!string.IsNullOrWhiteSpace(token))
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using (var response = await _client.PostAsync(requestUrl,
                new StringContent(contentBody,
                    Encoding.UTF8, "application/json"), cancellationToken))
            {
                responseClient = new Response
                {
                    StatusCode = response.StatusCode,
                    ContentStream = await response.Content.ReadAsStreamAsync(),
                    ContentString = await response.Content.ReadAsStringAsync(),
                    Issuccessful = response.IsSuccessStatusCode
                };
            }

            return responseClient;
        }
    }
}
