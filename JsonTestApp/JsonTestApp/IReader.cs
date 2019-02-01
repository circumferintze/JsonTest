using Newtonsoft.Json.Linq;

namespace JsonTestApp
{
    public interface IReader
    {
        string Read();
        JToken Convert(string input);
    }
}