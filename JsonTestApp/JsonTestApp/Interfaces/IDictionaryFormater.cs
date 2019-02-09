using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace JsonTestApp.Interfaces
{
    public interface IDictionaryFormater
    {
        Dictionary<string, JValue> Format(Dictionary<string, JValue> dictionary);
        Dictionary<IEnumerable<string>, string> ParseToDictionary(string file);
    }
}