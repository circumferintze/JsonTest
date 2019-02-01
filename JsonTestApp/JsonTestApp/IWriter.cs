using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace JsonTestApp
{
    public interface IWriter
    {
        void Write(Dictionary<string, JValue> dictionary);
    }
}