using JsonTestApp;
using JsonTestApp.Interfaces;
using NSubstitute;

namespace JsonTestProject
{
    public class JsonToTxtBuilder
    {
        private IReader _reader;
        private IDeserializer _deserializer;
        private IDictionaryWriter _writer;
        private IFormater _formater;

        public JsonToTxtBuilder()
        {
            _reader = Substitute.For<IReader>();
            _deserializer = Substitute.For<IDeserializer>();
            _writer = Substitute.For<IDictionaryWriter>();
            _formater = Substitute.For<IFormater>();
        }

        public JsonToTxtBuilder WithReader(IReader reader)
        {
            _reader = reader;
            return this;
        }

        public JsonToTxtBuilder WithDeserializer(IDeserializer deserializer)
        {
            _deserializer = deserializer;
            return this;
        }

        public JsonToTxtBuilder WithWriter(IDictionaryWriter writer)
        {
            _writer = writer;
            return this;
        }

        public JsonToTxtBuilder WithFormater(IFormater formater)
        {
            _formater = formater;
            return this;
        }

        public JsonToTxtConverter Build()
        {
            return new JsonToTxtConverter(_reader, _deserializer, _writer, _formater);
        }
    }
}