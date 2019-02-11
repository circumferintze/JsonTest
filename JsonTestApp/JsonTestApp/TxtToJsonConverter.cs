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
                var prop = CreateFields(item.Key, item.Value).Properties().First();
                if (jsonObject.Properties().Select(p => p.Name).Any(n => n == prop.Name))
                {
                    jsonObject[prop.Name] = MergeJson(jsonObject[prop.Name].ToObject<JObject>().Properties(),
                                           prop.Value.ToObject<JObject>().Properties().First());
                }
                else
                {
                    jsonObject.Add(prop);
                }
            }

            return jsonObject;
        }

        public JToken MergeJson(IEnumerable<JProperty> existing, JProperty more)
        {
            var jsonObject = new JObject();

            var same = existing.FirstOrDefault(p => p.Name == more.Name);

            if (same != null)
            {
                same.Value = MergeJson(same.Value.ToObject<JObject>().Properties(),
                    more.Value.ToObject<JObject>().Properties().First());

                foreach (var prop in existing)
                {
                    jsonObject.Add(prop.Name, prop.Value);
                }
            }
            else
            {
                foreach (var prop in existing)
                {
                    jsonObject.Add(prop.Name, prop.Value);
                }

                jsonObject.Add(more.Name, more.Value);
            }

            return jsonObject;
        }

        public JObject CreateFields(IEnumerable<string> keys, string value)
        {
            var jsonObject = new JObject();

            if (keys.Count() == 1)
            {
                jsonObject.Add(keys.ElementAt(0), value);
            }
            else
            {
                jsonObject.Add(keys.ElementAt(0), CreateFields(keys.Skip(1), value));
            }

            return jsonObject;
        }
    }
}