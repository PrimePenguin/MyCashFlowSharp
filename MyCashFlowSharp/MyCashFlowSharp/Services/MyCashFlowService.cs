using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MyCashFlowSharp.Infrastructure;
using MyCashFlowSharp.Infrastructure.Policies;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Services
{
    public abstract class MyCashFlowService
    {
        private static IRequestExecutionPolicy _GlobalExecutionPolicy = new DefaultRequestExecutionPolicy();

        private IRequestExecutionPolicy _ExecutionPolicy;

        private static HttpClient _Client { get; } = new HttpClient();

        protected Uri _ShopUri { get; set; }

        protected string _apiKey { get; set; }

        protected string _storeName { get; set; }

        protected string _userName { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="MyCashFlowException" />.
        /// </summary>
        /// <param name="storeName">store name</param>
        /// <param name="userName">User name</param>
        /// <param name="apiKey">An API access token for the shop.</param>
        protected MyCashFlowService(string storeName, string userName, string apiKey)
        {
            _apiKey = apiKey;
            _userName = userName;
            _storeName = storeName;
            _ShopUri = BuildMyCashFlowApiUri();

            // If there's a global execution policy it should be set as this instance's policy.
            // User can override it with instance-specific execution policy.
            _ExecutionPolicy = _GlobalExecutionPolicy ?? new DefaultRequestExecutionPolicy();
        }

        /// <summary>
        /// Attempts to build a shop API <see cref="Uri"/> for the given shop. Will throw a <see cref="MyCashFlowException"/> if the URL cannot be formatted.
        /// </summary>
        /// <exception cref="MyCashFlowException">Thrown if the given URL cannot be converted into a well-formed URI.</exception>
        /// <returns>The shop's API <see cref="Uri"/>.</returns>
        public Uri BuildMyCashFlowApiUri() => new Uri($"https://{_storeName}.mycashflow.fi");

        protected RequestUri PrepareRequest(string path) => new RequestUri(new Uri($"https://{_storeName}.mycashflow.fi/api/v1/{path}"));

        protected RequestUri PrepareRequest(string apiVersion, string path) => new RequestUri(new Uri($"https://{_storeName}.mycashflow.fi/api/{apiVersion}/{path}"));

        /// <summary>
        /// Prepares a request to the path and appends the shop's access token header if applicable.
        /// </summary>
        protected CloneableRequestMessage PrepareRequestMessage(RequestUri uri, HttpMethod method, HttpContent content = null)
        {
            var msg = new CloneableRequestMessage(uri.ToUri(), method, content);
            msg.Headers.Add("Accept", "application/json");
            return msg;
        }

        /// <summary>
        /// Executes a request and returns the given type. Throws an exception when the response is invalid.
        /// Use this method when the expected response is a single line or simple object that doesn't warrant its own class.
        /// </summary>
        protected async Task<T> ExecuteRequestAsync<T>(RequestUri uri, HttpMethod method, HttpContent content = null, string rootElement = null)
        {
            using (var baseRequestMessage = PrepareRequestMessage(uri, method, content))
            {
                var policyResult = await _ExecutionPolicy.Run(baseRequestMessage, async requestMessage =>
                {
                    // update client for basic authentication
                    var byteArray = Encoding.ASCII.GetBytes($"{_userName}:{_apiKey}");
                    _Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    var request = _Client.SendAsync(requestMessage);
                    using (var response = await request)
                    {
                        var rawResult = await response.Content.ReadAsStringAsync();

                        //Check for and throw exception when necessary.
                        if (!string.IsNullOrEmpty(rawResult))
                        {
                            CheckResponseExceptions(response, rawResult);
                        }
                        // This method may fail when the method was Delete, which is intendend.
                        // Delete methods should not be parsing the response JSON and should instead
                        // be using the non-generic ExecuteRequestAsync.

                        var result = JsonConvert.DeserializeObject<T>(rawResult);
                        return new RequestResult<T>(response, result, rawResult);
                    }
                });

                return policyResult;
            }
        }

        /// <summary>
        /// Checks a response for exceptions or invalid status codes. Throws an exception when necessary.
        /// </summary>
        /// <param name="response">The response.</param>
        public static void CheckResponseExceptions(HttpResponseMessage response, string rawResponse)
        {
            int statusCode = (int)response.StatusCode;

            // No error if response was between 200 and 300.
            if (statusCode >= 200 && statusCode < 300)
            {
                return;
            }

            var code = response.StatusCode;

            // If the error was caused by reaching the API rate limit, throw a rate limit exception.
            if ((int)code == 429 /* Too many requests */)
            {
                string listMessage = "Exceeded 2 calls per second for api client. Reduce request rates to resume uninterrupted service.";
                var error = JsonConvert.DeserializeObject<MyCashFlowRateLimitException>(rawResponse);
                error.HttpStatusCode = code;
                error.Message = listMessage;
                throw error;
            }

            var defaultMessage = $"Response did not indicate success. Status: {(int)code} {response.ReasonPhrase}.";

            MyCashFlowException exception;
            try
            {
                exception = JsonConvert.DeserializeObject<MyCashFlowException>(rawResponse);
            }
            catch (Exception e)
            {
                throw new MyCashFlowException(defaultMessage) { HttpStatusCode = code };
            }
            exception.HttpStatusCode = code;
            if (exception.Message == null) exception.Message = $"{defaultMessage}-{exception.Error}";
            throw exception;
        }
    }

    public static class CashFlow
    {
        public static string OrderEndPoints = "v0";
        public static string ImageDirectory = "tuotekuvat";
        public static string IncludeOrderParameters = "payments,products,products.return_reasons,shipments,tax_summary,comments,events";
        public static string IncludeProductParameters = "stock_item,translations,image_links,visibilities,variations.stock_item,variations";
    }
}
