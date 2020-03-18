using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MyCashFlowSharp.Infrastructure;

namespace MyCashFlowSharp.Helpers
{
    public static class MyCashFlowUtilities
    {
        public static async Task<bool> IsValidUri(string shopUri)
        {
            using (var client = new HttpClient())
            {
                using var msg = new HttpRequestMessage(HttpMethod.Get, GetRequestUri(shopUri).ToUri())
                {
                    Headers = { { "Accept", "application/json" } }
                };
                try
                {
                    var response = await client.SendAsync(msg);
                    var value = response.Headers.FirstOrDefault(c => c.Key.Contains("X-MCF-ID", StringComparison.CurrentCultureIgnoreCase)).Value.FirstOrDefault();
                    return value != "-";
                }
                catch (HttpRequestException)
                {
                    return false;
                }
            }
        }

        public static async Task<bool> IsValidCredentials(string shopUri, string userName, string apiKey)
        {
            using (var client = new HttpClient())
            {
                using var msg = new HttpRequestMessage(HttpMethod.Get, GetRequestUri(shopUri).ToUri())
                {
                    Headers = { { "Accept", "application/json" } }
                };
                try
                {
                    // update client for basic authentication
                    var byteArray = Encoding.ASCII.GetBytes($"{userName}:{apiKey}");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    var response = await client.SendAsync(msg);
                    var statusCode = (int)response.StatusCode;

                    return statusCode != 401;
                }
                catch (HttpRequestException)
                {
                    return false;
                }
            }
        }

        public static RequestUri GetRequestUri(string shopUri) => new RequestUri(new Uri($"{shopUri}/api/v1/products"));
    }
}
