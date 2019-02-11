using JsonTestApp.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp
{
    public class Formater : IFormater
    {
        public Dictionary<string, JValue> FormatDictionary(Dictionary<string, JValue> dictionary)
        {
            Dictionary<string, JValue> formatedDictionary = new Dictionary<string, JValue>();
            foreach (var item in dictionary)
            {
                var key = item.Key.Replace(".", @""".""");
                formatedDictionary.Add("\"" + key + "\"", item.Value);
            }

            return formatedDictionary;
        }

        public string FormatPath(string jsonObjectPath)
        {
            return jsonObjectPath.Trim(new char[] { '[' }).Replace("[", ".").Replace("]", "").Replace("'", "");
        }
    }
}