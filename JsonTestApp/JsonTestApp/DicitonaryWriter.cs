using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace JsonTestApp
{
    public class DictionaryWriter : IDictionaryWriter
    {
        private readonly string _arg;

        public DictionaryWriter(string arg)
        {
            _arg = arg;
        }
        public void Write(Dictionary<string, JValue> dictionary)
        {
            using (StreamWriter file = new StreamWriter(_arg))
                foreach (var field in dictionary)
                    file.WriteLine($"{field.Key}\t{field.Value}");
        }
    }
}