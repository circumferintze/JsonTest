using JsonTestApp.Interfaces;

namespace JsonTestApp
{
    public class Centralizer : ICentralizer
    {
        private readonly IReader _reader;
        private readonly IDeserializer _deserializer;
        private readonly IDictionaryWriter _dictionaryWriter;
        private readonly IDictionaryFormatter _formater;
        private readonly IJsonToTxtConverter _txtConverter;
        private readonly ITxtToJsonConverter _jsonConverter;
        private readonly IJsonWriter _jsonWriter;
        private readonly IDictionaryParser _dictionaryParser;

        public Centralizer(
            IReader reader,
            IDeserializer deserializer,
            IDictionaryWriter dictionaryWriter,
            IDictionaryFormatter formater,
            IJsonToTxtConverter txtConverter,
            IDictionaryParser dictionaryParser,
            ITxtToJsonConverter jsonConverter,
            IJsonWriter jsonWriter
            )
        {
            _reader = reader;
            _deserializer = deserializer;
            _dictionaryWriter = dictionaryWriter;
            _jsonWriter = jsonWriter;
            _dictionaryParser = dictionaryParser;
            _formater = formater;
            _txtConverter = txtConverter;
            _jsonConverter = jsonConverter;
        }

        public void ConvertJsonToTxt(string inputPath, string outputPath)
        {
            var file = _reader.Read(inputPath);
            var jsonObject = _deserializer.Deserialize(file);
            var dictionary = _txtConverter.GetFields(jsonObject);
            var formatedDictionary = _formater.FormatDictionary(dictionary);
            _dictionaryWriter.Write(formatedDictionary, outputPath);
        }

        public void ConvertTxtToJson(string inputPath, string outputPath)
        {
            var file = _reader.Read(inputPath);
            var dictionary = _dictionaryParser.ParseToDictionary(file);
            var json = _jsonConverter.CreateJson(dictionary);
            _jsonWriter.Write(json, outputPath);
        }
    }
}