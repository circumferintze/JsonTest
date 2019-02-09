using JsonTestApp.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace JsonTestApp
{
    public class JsonWriter : IJsonWriter
    {
        public void Writer (JObject j, string outputPath)
        {
            using (StreamWriter file = File.CreateText(outputPath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                j.WriteTo(writer);
            }
        }
    }
}
