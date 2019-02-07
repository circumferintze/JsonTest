using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JsonTestApp
{
    public class JSONSerializer
    {
        private List<string> inputList;
        private JObject json;
        private Dictionary<IEnumerable<string>, string> dictionary;

        public JSONSerializer()
        {
            inputList = new List<string>();
            json = new JObject();
            dictionary = new Dictionary<IEnumerable<string>, string>();
        }

        public JObject Read()
        {
            JObject obj = new JObject();

            string filePath = System.IO.Path.GetFullPath("output.txt");

            string input;
            using (StreamReader r = new StreamReader(filePath))
            {
                input = r.ReadToEnd();
            }

            var inputList = input.Replace("\"","").Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var dictionary = inputList.Select(x => x.Split('\t'))
                              .GroupBy(x => x[0].Split(new string[] {@"." }, StringSplitOptions.RemoveEmptyEntries))
                              .ToDictionary(x => x.Key.AsEnumerable(), x => x.Select(g => g[1]).Distinct().FirstOrDefault());

            foreach (var item in dictionary)
            {
                var prop = A(item.Key, item.Value).Properties().First();
                if (obj.Properties().Select(p => p.Name).Any(n => n == prop.Name))
                {
                    obj[prop.Name] = B(obj[prop.Name].ToObject<JObject>().Properties(),
                                           prop.Value.ToObject<JObject>().Properties().First());
                }
                else
                {
                    obj.Add(prop);
                }
            }

            return obj;
        }

        public JToken B(IEnumerable<JProperty> existing, JProperty more)
        {
            var obj = new JObject();

            var same = existing.FirstOrDefault(p => p.Name == more.Name);

            if (same != null)
            {
                same.Value = B(same.Value.ToObject<JObject>().Properties(),
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

        public JObject A(IEnumerable<string> keys, string value)
        {
            var jsonObject = new JObject();

            if (keys.Count() == 1)
            {
                jsonObject.Add(keys.ElementAt(0), value);
            }
            else
            {
                jsonObject.Add(keys.ElementAt(0), A(keys.Skip(1), value));
            }

            return jsonObject;
        }

        public void Writer2(JObject j)
        {
            using (StreamWriter file = File.CreateText(@"x.json"))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                j.WriteTo(writer);
            }
        }

        

        //for (int i = 0; i < inputArray.Length; ++i)
        //{
        //    var path = inputArray[i].Split(':')[i];
        //    var keys = path.Split('.');
        //    var value = inputArray[i].Split(':')[i+1];
        //}

        //for (int i = 0; i < value.Length; i++)
        //{
        //    if (value[i].Contains("."))
        //    {
        //        var temp1 = value[i].Substring(0, value[i].IndexOf("."));
        //        var temp2 = value[i+1].Substring(0, value[i+1].IndexOf("."));
        //        if (temp1 == temp2)
        //        {
        //            // json.Add(new JProperty(temp));
        //            value[i] = value[i].Replace(temp1, "").TrimStart('.');
        //        }
        //        //Iterator(result);
        //    }
        //}

        //var t = 1;

        //public JObject Iterator(string[] value)
        //{
        //    for (int i = 0; i < value.Length; i++)
        //    {
        //        var temp = value[i].Substring(0, value[i].IndexOf("."));
        //        value[i] = value[i].Replace(temp, "").TrimStart('.');
        //    }

        //    return new JObject(temp, Iterator(value));
        //}
    }
}