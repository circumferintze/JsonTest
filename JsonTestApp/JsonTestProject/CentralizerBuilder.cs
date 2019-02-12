using JsonTestApp;
using JsonTestApp.Interfaces;
using NSubstitute;

namespace JsonTestProject
{
    public class CentralizerBuilder
    {
        private IReader _reader;
        private IDeserializer _deserializer;
        private IDictionaryWriter _dictionaryWriter;
        private IDictionaryFormatter _formater;
        private IJsonToTxtConverter _txtConverter;
        private ITxtToJsonConverter _jsonConverter;
        private IJsonWriter _jsonWriter;
        private IDictionaryParser _dictionaryParser;

        public CentralizerBuilder()
        {
            _reader = Substitute.For<IReader>();
            _deserializer = Substitute.For<IDeserializer>();
            _dictionaryWriter = Substitute.For<IDictionaryWriter>();
            _formater = Substitute.For<IDictionaryFormatter>();
            _txtConverter = Substitute.For<IJsonToTxtConverter>();
            _jsonConverter = Substitute.For<ITxtToJsonConverter>();
            _jsonWriter = Substitute.For<IJsonWriter>();
            _dictionaryParser = Substitute.For<IDictionaryParser>();
    }

        public CentralizerBuilder WithReader(IReader reader)
        {
            _reader = reader;
            return this;
        }

        public CentralizerBuilder WithDeserializer(IDeserializer deserializer)
        {
            _deserializer = deserializer;
            return this;
        }

        public CentralizerBuilder WithDictionaryWriter(IDictionaryWriter dictionaryWriter)
        {
            _dictionaryWriter = dictionaryWriter;
            return this;
        }

        public CentralizerBuilder WithFormater(IDictionaryFormatter formater)
        {
            _formater = formater;
            return this;
        }

        public CentralizerBuilder WithJsonToTxtConverter(IJsonToTxtConverter txtConverter)
        {
            _txtConverter = txtConverter;
            return this;
        }

        public CentralizerBuilder WithJsonToTxtConverter(ITxtToJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
            return this;
        }

        public CentralizerBuilder WithJsonWriter(IJsonWriter jsonWriter)
        {
            _jsonWriter = jsonWriter;
            return this;
        }

        public CentralizerBuilder WithDictionaryParser(IDictionaryParser dictionaryParser)
        {
            _dictionaryParser = dictionaryParser;
            return this;
        }


        public Centralizer Build()
        {
            return new Centralizer(_reader, _deserializer, _dictionaryWriter, _formater,
                _txtConverter, _dictionaryParser, _jsonConverter, _jsonWriter );
        }
    }
}