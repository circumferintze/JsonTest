using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp
{
    public interface IWriter
    {
        void Write(Dictionary<string, JValue> dictionary);
    }
}