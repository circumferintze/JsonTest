using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTestApp.Interfaces
{
    public interface IDeserializer
    {
        JToken Deserialize(string input);
    }
}
