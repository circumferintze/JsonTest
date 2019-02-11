using JsonTestApp.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace JsonTestApp
{
    public class TxtToJsonConverter : ITxtToJsonConverter
    {
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