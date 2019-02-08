using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace JsonTestApp
{
    public class Writer : IWriter
    {
        public void Write(Dictionary<string, JValue> dictionary)
        {
            using (StreamWriter file = new StreamWriter("output.txt"))
                foreach (var field in dictionary)
                    file.WriteLine($"{field.Key}\t{field.Value}");
        }
    }
}