using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace JsonTestApp
{
    public class Reader : IReader
    {
        public string Read()
        {
            string filePath = System.IO.Path.GetFullPath("dataModel.json");

            string input;
            using (StreamReader r = new StreamReader(filePath))
            {
                input = r.ReadToEnd();
            }

            return input;
        }

        public JToken Convert(string input)
        {
            JToken jsonObject = JsonConvert.DeserializeObject<JToken>(input);

            return jsonObject;
        }

        public void Deserialize()
        {

        }
    }
}