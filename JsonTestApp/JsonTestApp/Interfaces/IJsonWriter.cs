using Newtonsoft.Json.Linq;

namespace JsonTestApp
{
    public interface IJsonWriter
    {
        void Writer(JObject j);
    }
}