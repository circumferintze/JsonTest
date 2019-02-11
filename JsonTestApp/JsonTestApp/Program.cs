using System;
using Unity;

namespace JsonTestApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Container unityContainer = new Container();
            var container = unityContainer.Get();

            JsonToTxtConverter txtConverter = container.Resolve<JsonToTxtConverter>();
            TxtToJsonConverter jsonConverter = container.Resolve<TxtToJsonConverter>();

            var extension = args[0].Split('.');
            switch (extension[1].ToUpper())
            {
                case "JSON":
                    {
                        txtConverter.Convert(args[0], args[1]);
                        break;
                    }
                case "TXT":
                    {
                        jsonConverter.Convert(args[0], args[1]);
                        break;
                    }

                default:
                    Console.WriteLine("Invalid file extension");
                    break;
            }
        }
    }
}