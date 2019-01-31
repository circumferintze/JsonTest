using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp
{
    public class JsonDeserializer : IJsonDeserializer
    {
        private readonly Dictionary<string, JValue> fields;

        public JsonDeserializer()
        {
            fields = new Dictionary<string, JValue>();
        }

        public Dictionary<string, JValue> GetFields(JToken jsonObject)
        {
            switch (jsonObject.Type)
            {
                case JTokenType.Object:
                    foreach (var child in jsonObject.Children<JProperty>())
                        GetFields(child);
                    break;

                case JTokenType.Array:
                    foreach (var child in jsonObject.Children())
                        GetFields(child);
                    break;

                case JTokenType.Property:
                    GetFields(((JProperty)jsonObject).Value);
                    break;

                default:
                    fields.Add(jsonObject.Path, (JValue)jsonObject);
                    break;
            }

            return fields;
        }
    }
}