using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp.Interfaces
{
    public interface IDictionaryFormatter
    {
        Dictionary<string, JValue> FormatDictionary(Dictionary<string, JValue> dictionary);
    }
}