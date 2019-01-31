using System;

namespace JsonTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader x = new Reader();
            var jToken = x.Convert();
            JsonDeserializer j = new JsonDeserializer();
            var fields = j.GetFields(jToken);

            foreach (var field in fields)
                Console.WriteLine($"{field.Key} : {field.Value}");

            Console.ReadKey();
        }
    }
}
