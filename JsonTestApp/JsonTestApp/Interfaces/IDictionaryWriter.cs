using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestApp.Interfaces
{
    public interface IDictionaryWriter
    {
        void Write(Dictionary<string, JValue> dictionary, string outputPath);
    }
}