using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyCashFlowSharp.Helpers
{
    public class CustomAttributeArrayValueConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if ((string)reader.Value == null)
            {
                try
                {
                    var jObject = JObject.Load(reader);
                    return jObject.ToObject(objectType);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return (string)reader.Value;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
