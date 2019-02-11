using JsonTestApp;
using JsonTestApp.Interfaces;
using NSubstitute;

namespace JsonTestProject
{
    public class TxtToJsonBuilder
    {
        private IReader _reader;
        private IJsonWriter _writer;
        private IDictionaryParser _dictionaryParser;

        public TxtToJsonBuilder()
        {
            _reader = Substitute.For<IReader>();
            _writer = Substitute.For<IJsonWriter>();
            _dictionaryParser = Substitute.For<IDictionaryParser>();
        }

        public TxtToJsonBuilder WithReader(IReader reader)
        {
            _reader = reader;
            return this;
        }

        public TxtToJsonBuilder WithWriter(IJsonWriter writer)
        {
            _writer = writer;
            return this;
        }

        public TxtToJsonBuilder WithDictionaryParser(IDictionaryParser dictionaryParser)
        {
            _dictionaryParser = dictionaryParser;
            return this;
        }

        public TxtToJsonConverter Build()
        {
            return new TxtToJsonConverter(_reader, _writer, _dictionaryParser);
        }
    }
}