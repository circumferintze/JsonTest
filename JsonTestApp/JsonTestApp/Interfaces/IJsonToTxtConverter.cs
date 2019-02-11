using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp.Interfaces
{
    public interface IJsonToTxtConverter
    {
        void Convert(string inputPath, string outputPath);

        Dictionary<string, JValue> GetFields(JToken jsonObject);
    }
}