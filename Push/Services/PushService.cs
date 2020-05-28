using Newtonsoft.Json;
using Push.Common.Settings;
using Push.Core.Client;
using Push.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Push.Services
{
    public class PushService : IPushService
    {
        private IWebClient _webClient;
        private CancellationTokenSource _cancellationTokenSource;

        public PushService()
        {
            var httpClient = new HttpClient();
            _webClient = new WebClient(httpClient);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async  Task<Token> GetAuthenticationToken(IApiSettings settings)
        {
            var body = $"username={settings.User}&password={settings.Password}&grant_type=password";
            var response = await _webClient.InvokePost(_cancellationTokenSource.Token, body, settings.BaseUrl, "token");

            return JsonConvert.DeserializeObject<Token>(response.ContentString);
        }

        public async Task Push(IApiSettings settings, Token token)
        {
            throw new NotImplementedException();
        }
    }
}
