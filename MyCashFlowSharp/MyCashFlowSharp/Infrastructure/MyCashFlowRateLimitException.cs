using System.Collections.Generic;
using System.Net;

namespace MyCashFlowSharp.Infrastructure
{
    /// <summary>
    /// An exception thrown when an API call has reached QuickbutikSharp's rate limit.
    /// </summary>
    public class MyCashFlowRateLimitException : MyCashFlowException
    {
        public MyCashFlowRateLimitException()
        { }

        public MyCashFlowRateLimitException(string message) : base(message) { }

        public MyCashFlowRateLimitException(HttpStatusCode httpStatusCode, string message, int code, string error) : base(httpStatusCode, message, code, error) { }
    }
}
