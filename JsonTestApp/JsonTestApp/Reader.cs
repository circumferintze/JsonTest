using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace JsonTestApp
{
    public class Reader : IReader
    {
            public JToken Convert()
        {
            string filePath = System.IO.Path.GetFullPath("dataModel.json");

            string jsonInput;
            using (StreamReader r = new StreamReader(filePath))
            {
                jsonInput = r.ReadToEnd();
            }

            JToken jsonObject = JsonConvert.DeserializeObject<JToken>(jsonInput);

            return jsonObject;
        }
    }
}
