using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp.Interfaces
{
    public interface ITxtToJsonConverter
    {
        void Convert(string inputPath, string outputPath);

        JObject CreateJson(Dictionary<IEnumerable<string>, string> dictionary);
    }
}