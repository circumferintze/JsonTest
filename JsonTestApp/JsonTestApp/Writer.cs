using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
