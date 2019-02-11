using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp.Interfaces
{
    public interface IJsonToTxtConverter
    {
        Dictionary<string, JValue> GetFields(JToken jsonObject);
    }
}