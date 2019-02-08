using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace JsonTestApp
{
    public class JsonWriter : IJsonWriter
    {
        private readonly string _arg;

        public JsonWriter(string arg)
        {
            _arg = arg;
        }
        public void Writer (JObject j)
        {
            using (StreamWriter file = File.CreateText(_arg))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                j.WriteTo(writer);
            }
        }
    }
}
