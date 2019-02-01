using System;

namespace JsonTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader x = new Reader();
            var input = x.Read();

            var jToken = x.Convert(input);

            JsonDeserializer j = new JsonDeserializer();
            var fields = j.GetFields(jToken);

            Writer w = new Writer();
            w.Write(fields);

            JSONSerializer js = new JSONSerializer();
            js.Serialize();

            Console.ReadKey();
        }
    }
}
