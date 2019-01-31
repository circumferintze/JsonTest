using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace JsonTestApp
{
    public interface IJsonDeserializer
    {
        Dictionary<string, JValue> GetFields(JToken jsonObject);
    }
}