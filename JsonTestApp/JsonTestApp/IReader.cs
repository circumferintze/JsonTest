using Newtonsoft.Json.Linq;

namespace JsonTestApp
{
    public interface IReader
    {
        JToken Convert();
    }
}