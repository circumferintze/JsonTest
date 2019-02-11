using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp.Interfaces
{
    public interface IFormater
    {
        Dictionary<string, JValue> FormatDictionary(Dictionary<string, JValue> dictionary);
        string FormatPath(string jsonObjectPath);
    }
}