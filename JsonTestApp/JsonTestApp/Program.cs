using System;
using Unity;
using JsonTestApp.Interfaces;
using Unity.Injection;

namespace JsonTestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<JsonToTxtConverter>();
            container.RegisterType<TxtToJsonConverter>();
            container.RegisterType<IReader, Reader>();
            container.RegisterType<IDeserializer, Deserializer>();
            container.RegisterType<IDictionaryWriter, DictionaryWriter>();
            container.RegisterType<IDictionaryFormater, DictionaryFormater>();
            container.RegisterType<IJsonWriter, JsonWriter>();
            
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