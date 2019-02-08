using System.IO;

namespace JsonTestApp
{
    public class Reader : IReader
    {
        private readonly string _arg;

        public Reader(string arg)
        {
            _arg = arg;
        }
        public string Read()
        {
            string filePath = System.IO.Path.GetFullPath(_arg);

            string file;
            using (StreamReader r = new StreamReader(filePath))
            {
                file = r.ReadToEnd();
            }

            return file;
        }
    }
}