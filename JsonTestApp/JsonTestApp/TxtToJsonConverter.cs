using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonTestApp
{
    public class TxtToJsonConverter
    {
        private List<string> inputList;
        private JObject json;
        private Dictionary<IEnumerable<string>, string> dictionary;
        private readonly IReader _reader;

        public TxtToJsonConverter(IReader reader)
        {
            inputList = new List<string>();
            json = new JObject();
            dictionary = new Dictionary<IEnumerable<string>, string>();
            _reader = reader;
        }

        public void Convert()
        {
            var file = _reader.Read();
        }

        private Dictionary<IEnumerable<string>, string> ParseToDictionary (string file)
        {
            var inputList = file.Replace("\"", "").Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var dictionary = inputList.Select(x => x.Split('\t'))
                              .GroupBy(x => x[0].Split(new string[] { @"." }, StringSplitOptions.RemoveEmptyEntries))
                              .ToDictionary(x => x.Key.AsEnumerable(), x => x.Select(g => g[1]).Distinct().FirstOrDefault());

            return dictionary;
        }
        public JObject CreateJson()
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
            var obj = new JObject();

            var same = existing.FirstOrDefault(p => p.Name == more.Name);

            if (same != null)
            {
                same.Value = MergeJson(same.Value.ToObject<JObject>().Properties(),
                    more.Value.ToObject<JObject>().Properties().First());

                foreach (var prop in existing)
                {
                    obj.Add(prop.Name, prop.Value);
                }
            }
            else
            {
                foreach (var prop in existing)
                {
                    obj.Add(prop.Name, prop.Value);
                }

                obj.Add(more.Name, more.Value);
            }

            return obj;
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