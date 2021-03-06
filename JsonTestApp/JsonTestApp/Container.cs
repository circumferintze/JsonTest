﻿using JsonTestApp.Interfaces;
using Unity;

namespace JsonTestApp
{
    public class Container
    {
        public IUnityContainer Get()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<Centralizer>();
            container.RegisterSingleton<IJsonToTxtConverter, JsonToTxtConverter>();
            container.RegisterSingleton<ITxtToJsonConverter, TxtToJsonConverter>();
            container.RegisterSingleton<IReader, Reader>();
            container.RegisterSingleton<IDeserializer, Deserializer>();
            container.RegisterSingleton<IDictionaryWriter, DictionaryWriter>();
            container.RegisterSingleton<IDictionaryFormatter, DictionaryFormatter>();
            container.RegisterSingleton<IJsonWriter, JsonWriter>();
            container.RegisterSingleton<IDictionaryParser, DictionaryParser>();

            return container;
        }
    }
}