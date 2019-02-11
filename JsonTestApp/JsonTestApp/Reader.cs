using JsonTestApp.Interfaces;
using System.IO;

namespace JsonTestApp
{
    public class Reader : IReader
    {
        public string Read(string inputPath)
        {
            string filePath = System.IO.Path.GetFullPath(inputPath);

            string file;
            using (StreamReader r = new StreamReader(filePath))
            {
                file = r.ReadToEnd();
            }

            return file;
        }
    }
}