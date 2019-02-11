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
        private readonly IFormater _formater;

        public JsonToTxtConverter(IReader reader, IDeserializer deserializer, IDictionaryWriter writer, IFormater formater)
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
                    fields.Add(_formater.FormatPath(jsonObject.Path),
                        (JValue)jsonObject);
                    break;
            }

            return _formater.FormatDictionary(fields);
        }
    }
}