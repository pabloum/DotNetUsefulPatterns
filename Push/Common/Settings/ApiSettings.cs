using System;
using System.Collections.Generic;
using System.Text;

namespace Push.Common.Settings
{
    public interface IApiSettings
    {
        string BaseUrl { get; set; }
        int MaximumRetryNumberLimit { get; set; }
        string User { get; set; }
        string Password { get; set; }
        string CanAppEndpoint { get; set; }
        string RecEndpoint { get; set; }
        public string RequEndpoint { get; set; }
    }

    public class ApiSettings : IApiSettings
    {
        public string BaseUrl { get; set; }
        public int MaximumRetryNumberLimit { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string CanAppEndpoint { get; set; }
        public string RecEndpoint { get; set; }
        public string RequEndpoint { get; set; }
    }
}
