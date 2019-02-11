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

            var centralizer = container.Resolve<Centralizer>();

            var extension = args[0].Split('.');
            switch (extension[1].ToUpper())
            {
                case "JSON":
                    {
                        centralizer.ConvertJsonToTxt(args[0], args[1]);
                        break;
                    }
                case "TXT":
                    {
                        centralizer.ConvertTxtToJson(args[0], args[1]);
                        break;
                    }

                default:
                    Console.WriteLine("Invalid file extension");
                    break;
            }
        }
    }
}