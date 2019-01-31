using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace JsonTestApp
{
    public class JSONConvertor
    {
        private readonly Dictionary<string, JValue> fields;
        public JSONConvertor(JToken token)
        {
            fields = new Dictionary<string, JValue>();
            GetFields(token);
        }
        public IEnumerable<KeyValuePair<string, JValue>> GetAllFields()
        {
            return fields;
        }
        private void GetFields(JToken jsonObject)
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
        }
        }
    }

