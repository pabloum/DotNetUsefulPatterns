using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Push.Entities
{

    /// <summary>
    ///     It represents an access token
    /// </summary>
    public class Token
    {
        [JsonProperty("expires_in")] public string ExpiresIn { get; set; }

        [JsonProperty("token_type")] public string TokenType { get; set; }

        [JsonProperty("access_token")] public string AccessToken { get; set; }
    }
}
