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
            container.RegisterType<IReader, Reader>();
            container.RegisterType<IDeserializer, Deserializer>();
            container.RegisterType<IDictionaryWriter, DictionaryWriter>();
            container.RegisterType<IFormater, Formater>();
            container.RegisterType<IJsonWriter, JsonWriter>();
            container.RegisterType<IDictionaryParser, DictionaryParser>();

            return container;
        }
    }
}