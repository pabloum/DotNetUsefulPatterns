using System;
using Push.Common.Settings;
using Push.Services;
using Nito.AsyncEx.Synchronous;
using System.Collections.Generic;
using Push.Common.Constants;

namespace Push
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My horse is amazing!");

            // ToDo: Dependency injection
            // ToDo: Hide this information
            var endpointSettings = new ApiSettings
            {
                BaseUrl = "",
                MaximumRetryNumberLimit = 5,
                User = "",
                Password = "",
                CanAppEndpoint = "",
                RecEndpoint = "",
                RequEndpoint = ""
            };

            var pushService = new PushService();

            try
            {
                var token = pushService.GetAuthenticationToken(endpointSettings).WaitAndUnwrapException();

                if (token != null && !string.IsNullOrEmpty(token.AccessToken))
                {
                    pushService.Push(endpointSettings, token).WaitAndUnwrapException();
                }
                else
                {
                    Console.WriteLine(PushConstants.MissingTokenMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            //var _response = new APIGatewayProxyResponse
            //{
            //    StatusCode = (int) HttpStatusCode.OK,
            //    Headers = new Dictionary<string, string> {{"Content-Type", "text/plain"}}
            //};
        }
    }
}
