using Newtonsoft.Json;

namespace MyCashFlowSharp.Infrastructure
{
    /// <summary>
    /// Contains JSON serialization settings and methods used by the rest of the WixSharp package.
    /// </summary>
    public static class Serializer
    {
        public static JsonSerializerSettings Settings { get; } = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public static string Serialize(object data) => JsonConvert.SerializeObject(data, Settings);
    }
}