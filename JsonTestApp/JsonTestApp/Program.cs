using CommandLine;
using System;

namespace JsonTestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var inputPath = args[0];
            var extension = inputPath.Split('.');
            switch (extension[1].ToUpper())
            {
                case "JSON":
                    {
                        Reader reader = new Reader(inputPath);
                        Deserializer des = new Deserializer();
                        DictionaryWriter wr = new DictionaryWriter(args[1]);
                        DictionaryFormater df = new DictionaryFormater();
                        JsonToTxtConverter js = new JsonToTxtConverter(reader, des, wr, df);
                        js.Convert();
                        break;
                    }
                case "TXT":
                    {
                        Reader reader = new Reader(inputPath);
                        DictionaryFormater df = new DictionaryFormater();
                        JsonWriter jw = new JsonWriter();
                        TxtToJsonConverter tj = new TxtToJsonConverter(reader, jw, df);
                        break;
                    }

                default:
                    Console.WriteLine("Invalid file extension");
                    break;
            }
    
        }
    }
}