using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp.Interfaces
{
    public interface ITxtToJsonConverter
    {
        void Convert(string inputPath, string outputPath);

        JProperty CreateFields(IEnumerable<string> keys, string value);

        JObject CreateJson(Dictionary<IEnumerable<string>, string> dictionary);

    }
}