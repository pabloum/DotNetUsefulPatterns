using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace Push.Core.Client
{
    public class Response
    {
        /// <summary>
        ///     Response content string
        /// </summary>
        public string ContentString { get; set; }

        /// <summary>
        ///     Response content stream
        /// </summary>
        public Stream ContentStream { get; set; }

        /// <summary>
        ///     Whether it was successful the response or not
        /// </summary>
        public bool Issuccessful { get; set; }

        /// <summary>
        ///     Status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}
