using JsonTestApp.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp
{
    public class JsonToTxtConverter : IJsonToTxtConverter
    {
        private readonly Dictionary<string, JValue> fields;
        private readonly IReader _reader;
        private readonly IDeserializer _deserializer;
        private readonly IDictionaryWriter _writer;
        private readonly IDictionaryFormater _formater;

        public JsonToTxtConverter(IReader reader, IDeserializer deserializer, IDictionaryWriter writer, IDictionaryFormater formater)
        {
            fields = new Dictionary<string, JValue>();
            _reader = reader;
            _deserializer = deserializer;
            _writer = writer;
            _formater = formater;
        }

        public void Convert(string inputPath, string outputPath)
        {
            var file = _reader.Read(inputPath);
            var jsonObject = _deserializer.Deserialize(file);
            var dictionary = GetFields(jsonObject);
            _writer.Write(dictionary, outputPath);
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

            return _formater.Format(fields);
        }
        
    }
}