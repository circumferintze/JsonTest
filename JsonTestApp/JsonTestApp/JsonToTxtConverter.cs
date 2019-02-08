using JsonTestApp.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp
{
    public class JsonToTxtConverter 
    {
        private readonly Dictionary<string, JValue> fields;
        private readonly IReader _reader;
        private readonly IDeserializer _deserializer;
        private readonly IDictionaryWriter _writer;

        public JsonToTxtConverter(IReader reader, IDeserializer deserializer, IDictionaryWriter writer)
        {
            fields = new Dictionary<string, JValue>();
            _reader = reader;
            _deserializer = deserializer;
            _writer = writer;
        }

        public void Convert()
        {
            var file = _reader.Read();
            var jsonObject = _deserializer.Deserialize(file);
            var dictionary = GetFields(jsonObject);
            _writer.Write(dictionary);
        }

        private Dictionary<string, JValue> GetFields(JToken jsonObject)
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
                    fields.Add(jsonObject.Path.Trim(new char[] { '[' }).Replace("[", ".").Replace("]", "").Replace("'", ""), 
                        (JValue)jsonObject);
                    break;
            }

            //return fields;
            return Format(fields);
        }
        private Dictionary<string, JValue> Format(Dictionary<string, JValue> dictionary)
        {
            Dictionary<string, JValue> formatedDictionary = new Dictionary<string, JValue>();
            foreach (var item in dictionary)
            {
                var key = item.Key.Replace(".", @""".""");
                formatedDictionary.Add("\"" + key + "\"", item.Value);
            }

            return formatedDictionary;
        }
    }
}