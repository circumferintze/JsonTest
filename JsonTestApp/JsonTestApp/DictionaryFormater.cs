using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTestApp
{
    public class DictionaryFormater : IDictionaryFormater
    {
        public Dictionary<string, JValue> Format(Dictionary<string, JValue> dictionary)
        {
            Dictionary<string, JValue> formatedDictionary = new Dictionary<string, JValue>();
            foreach (var item in dictionary)
            {
                var key = item.Key.Replace(".", @""".""");
                formatedDictionary.Add("\"" + key + "\"", item.Value);
            }

            return formatedDictionary;
        }

        public Dictionary<IEnumerable<string>, string> ParseToDictionary(string file)
        {
            var inputList = file.Replace("\"", "").Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var dictionary = inputList.Select(x => x.Split('\t'))
                              .GroupBy(x => x[0].Split(new string[] { @"." }, StringSplitOptions.RemoveEmptyEntries))
                              .ToDictionary(x => x.Key.AsEnumerable(), x => x.Select(g => g[1]).Distinct().FirstOrDefault());

            return dictionary;
        }
    }
}
