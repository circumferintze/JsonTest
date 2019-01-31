using System;

namespace JsonTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader x = new Reader();
            var jToken = x.Convert();
            JSONConvertor j = new JSONConvertor(jToken);
            var fields = j.GetAllFields();

            foreach (var field in fields)
                Console.WriteLine($"{field.Key} : {field.Value}");

            Console.ReadKey();
        }
    }
}
