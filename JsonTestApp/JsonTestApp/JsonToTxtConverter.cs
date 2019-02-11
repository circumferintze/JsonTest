using JsonTestApp.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp
{
    public class JsonToTxtConverter : IJsonToTxtConverter
    {
        private readonly Dictionary<string, JValue> fields;

        public JsonToTxtConverter()
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

                case JTokenType.Property:
                    GetFields(((JProperty)jsonObject).Value);
                    break;

                default:
                    fields.Add(jsonObject.Path,
                        (JValue)jsonObject);
                    break;
            }

            return fields;
        }
    }
}