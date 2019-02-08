using CommandLine;
using System;

namespace JsonTestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var inputPath = args[0];
            Reader reader = new Reader(inputPath);
            Deserializer des = new Deserializer();
            DictionaryWriter wr = new DictionaryWriter(args[1]);
            JsonToTxtConverter js = new JsonToTxtConverter(reader, des, wr);
            js.Convert();

            Console.ReadKey();
        }
    }
}