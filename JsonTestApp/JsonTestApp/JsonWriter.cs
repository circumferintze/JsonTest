using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace JsonTestApp
{
    public class JsonWriter : IJsonWriter
    {
        public void Writer (JObject j)
        {
            using (StreamWriter file = File.CreateText(@"x.json"))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                j.WriteTo(writer);
            }
        }
    }
}
