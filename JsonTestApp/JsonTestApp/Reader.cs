using System.IO;

namespace JsonTestApp
{
    public class Reader : IReader
    {
        private readonly string arg;

        public Reader(string arg)
        {
            this.arg = arg;
        }
        public string Read()
        {
            string filePath = System.IO.Path.GetFullPath(arg);

            string file;
            using (StreamReader r = new StreamReader(filePath))
            {
                file = r.ReadToEnd();
            }

            return file;
        }
    }
}