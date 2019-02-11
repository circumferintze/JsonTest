using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp.Interfaces
{
    public interface ITxtToJsonConverter
    {
        JObject CreateJson(Dictionary<IEnumerable<string>, string> dictionary);
    }
}