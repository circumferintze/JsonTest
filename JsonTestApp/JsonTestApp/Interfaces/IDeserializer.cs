using Newtonsoft.Json.Linq;

namespace JsonTestApp.Interfaces
{
    public interface IDeserializer
    {
        JToken Deserialize(string input);
    }
}
