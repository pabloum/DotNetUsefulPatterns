using Push.Common.Settings;
using Push.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Push.Services
{
    public interface IPushService
    {
        /// <summary>
        ///     Get Authentication token
        /// </summary>
        /// <param name="settings">Pre-hire settings</param>
        /// <returns>Returns the authentication token</returns>
        Task<Token> GetAuthenticationToken(IApiSettings settings);

        /// <summary>
        ///     Process the push to Pre Hire
        /// </summary>
        /// <param name="settings">Pre-hire settings</param>
        /// <param name="queueProcess">Queue process</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Return a task</returns>
        Task Push(IApiSettings settings, Token token);
    }
}
