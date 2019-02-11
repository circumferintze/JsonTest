using JsonTestApp.Interfaces;
using Unity;

namespace JsonTestApp
{
    public class Container
    {
        public IUnityContainer Get()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<JsonToTxtConverter>();
            container.RegisterType<TxtToJsonConverter>();
            container.RegisterSingleton<IReader, Reader>();
            container.RegisterSingleton<IDeserializer, Deserializer>();
            container.RegisterSingleton<IDictionaryWriter, DictionaryWriter>();
            container.RegisterSingleton<IFormater, Formater>();
            container.RegisterSingleton<IJsonWriter, JsonWriter>();
            container.RegisterSingleton<IDictionaryParser, DictionaryParser>();

            return container;
        }
    }
}