using JsonTestApp.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace JsonTestApp
{
    public class TxtToJsonConverter : ITxtToJsonConverter
    {
        private readonly IReader _reader;
        private readonly IJsonWriter _writer;
        private readonly IDictionaryParser _dictionaryParser;

        public TxtToJsonConverter(IReader reader, IJsonWriter writer, IDictionaryParser dictionaryParser)
        {
            _reader = reader;
            _writer = writer;
            _dictionaryParser = dictionaryParser;
        }

        public void Convert(string inputPath, string outputPath)
        {
            var file = _reader.Read(inputPath);
            var dictionary = _dictionaryParser.ParseToDictionary(file);
            var json = CreateJson(dictionary);
            _writer.Writer(json, outputPath);
        }

        public JObject CreateJson(Dictionary<IEnumerable<string>, string> dictionary)
        {
            JObject jsonObject = new JObject();
            foreach (var item in dictionary)
            {
                var temp = new JObject { CreateFields(item.Key, item.Value) };
                jsonObject.Merge(temp);
            }

            return jsonObject;
        }

        private JProperty CreateFields(IEnumerable<string> keys, string value)
        {
            var jsonObject = new JObject();

            if (keys.Count() == 1)
            {
                return new JProperty(keys.ElementAt(0), value);
            }
            else
            {
                return new JProperty(keys.First(), new JObject(CreateFields(keys.Skip(1), value)));
            }
        }
    }
}