using Newtonsoft.Json.Linq;

namespace JsonTestApp.Interfaces
{
    public interface IJsonWriter
    {
        void Write(JObject j, string outputPath);
    }
}