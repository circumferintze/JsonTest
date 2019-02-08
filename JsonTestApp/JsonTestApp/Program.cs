using CommandLine;
using System;

namespace JsonTestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var a = Parser.Default.ParseArguments<ArgsOptions>(args)
                   .WithParsed<ArgsOptions>(o =>
                   {
                       if (o.Verbose)
                       {
                           Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                       }
                       else
                       {
                           Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example!");
                       }
                   });

            Reader x = new Reader();
            var input = x.Read();

            var jToken = x.Convert(input);

            JsonToTxtConverter j = new JsonToTxtConverter();
            var fields = j.GetFields(jToken);
            var formatedFields = j.Format(fields);

            Writer w = new Writer();
            w.Write(formatedFields);

            JSONSerializer js = new JSONSerializer();
            var xxx = js.Read();

            js.Writer2(xxx);

            Console.ReadKey();
        }
    }
}