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
            var formatedFields = j.Format(fields);

            Writer w = new Writer();
            w.Write(formatedFields);

            JSONSerializer js = new JSONSerializer();
            var xxx = js.Read();
            
            js.Writer2(xxx);
        }
    }
}
