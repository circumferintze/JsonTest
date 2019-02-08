using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp
{
    public interface IDictionaryWriter
    {
        void Write(Dictionary<string, JValue> dictionary);
    }
}