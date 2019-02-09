using JsonTestApp.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace JsonTestApp
{
    public class DictionaryWriter : IDictionaryWriter
    {
        public void Write(Dictionary<string, JValue> dictionary, string outputPath)
        {
            using (StreamWriter file = new StreamWriter(outputPath))
                foreach (var field in dictionary)
                    file.WriteLine($"{field.Key}\t{field.Value}");
        }
    }
}