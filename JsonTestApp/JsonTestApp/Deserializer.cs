using JsonTestApp.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonTestApp
{
    public class Deserializer : IDeserializer
    {
        public JToken Deserialize(string input)
        {
            JToken jsonObject = JsonConvert.DeserializeObject<JToken>(input);

            return jsonObject;
        }
    }
}