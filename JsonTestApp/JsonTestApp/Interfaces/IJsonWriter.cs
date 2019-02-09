using Newtonsoft.Json.Linq;

namespace JsonTestApp.Interfaces
{
    public interface IJsonWriter
    {
        void Writer(JObject j, string outputPath);
    }
}