using JsonTestApp.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using NSubstitute;
using System.Collections.Generic;

namespace JsonTestProject
{
    [TestClass]
    public class CentralizerTests
    {
        [TestMethod]
        public void ConvertJsonToTxt_ReadMethod_ReceiveCall()
        {
            var reader = Substitute.For<IReader>();
            reader.Read("inputPath").Returns("file");
            
            var centralizer = new CentralizerBuilder().WithReader(reader).Build();
            centralizer.ConvertJsonToTxt("inputPath", "outputPath");

            reader.Received().Read("inputPath");

        }

        [TestMethod]
        public void ConvertJsonToTxt_WriteMethod_ReceiveCall()
        {
            var dictionaryWriter = Substitute.For<IDictionaryWriter>();
            Dictionary<string, JValue> dictionary = new Dictionary<string, JValue>();
            dictionary.Add("\"id1\".\"id2\"", (JValue)1);

            dictionaryWriter.Write(dictionary, "outputPath");

            var centralizer = new CentralizerBuilder().WithDictionaryWriter(dictionaryWriter).Build();
            centralizer.ConvertJsonToTxt("inputPath", "outputPath");

            dictionaryWriter.Received().Write(dictionary, "outputPath");
        }


        [TestMethod]
        public void ConvertJsonToTxt_DeserializeMethod_ReceiveCall()
        {
            var reader = Substitute.For<IReader>();
            reader.Read("inputPath").Returns("file");

            var deserializer = Substitute.For<IDeserializer>();

            var token = new JObject
               (
               new JProperty("id", "001"),
               new JProperty("image",
                   new JObject(new JProperty("url", "images / 0001.jpg"),
                               new JProperty("width", 200),
                               new JProperty("height", 200))));

            deserializer.Deserialize("file").Returns(token);

            var centralizer = new CentralizerBuilder().WithReader(reader).WithDeserializer(deserializer).Build();
            centralizer.ConvertJsonToTxt("inputPath", "outputPath");

            deserializer.Received().Deserialize("file");
        }


        [TestMethod]
        public void ConvertJsonToTxt_GetFieldsMethod_ReceiveCall()
        {
            var reader = Substitute.For<IReader>();
            var deserializer = Substitute.For<IDeserializer>();

            reader.Read("inputPath").Returns("file");

            var token = new JObject
               (
               new JProperty("id", "001"),
               new JProperty("image",
                   new JObject(new JProperty("url", "images / 0001.jpg"),
                               new JProperty("width", 200),
                               new JProperty("height", 200))));

            deserializer.Deserialize("file").Returns(token);

            var txtConverter = Substitute.For<IJsonToTxtConverter>();

             var dictionary = new Dictionary<string, JValue>();
            dictionary.Add("id", new JValue("001"));
            dictionary.Add("image.url", new JValue("images / 0001.jpg"));
            dictionary.Add("image.width", new JValue(200));
            dictionary.Add("image.height", new JValue(200));

            txtConverter.GetFields(token).Returns(dictionary);


            var centralizer = new CentralizerBuilder()
                                    .WithReader(reader)
                                    .WithDeserializer(deserializer)
                                    .WithJsonToTxtConverter(txtConverter)
                                    .Build();

            centralizer.ConvertJsonToTxt("inputPath", "outputPath");

            txtConverter.Received().GetFields(token);
        }

        [TestMethod]
        public void ConvertJsonToTxt_FormatDictionaryMethod_ReceiveCall()
        {
            var reader = Substitute.For<IReader>();
            var deserializer = Substitute.For<IDeserializer>();

            reader.Read("inputPath").Returns("file");

            var token = new JObject
               (
               new JProperty("id", "001"),
               new JProperty("image",
                   new JObject(new JProperty("url", "images / 0001.jpg"),
                               new JProperty("width", 200),
                               new JProperty("height", 200))));

            deserializer.Deserialize("file").Returns(token);

            var txtConverter = Substitute.For<IJsonToTxtConverter>();

            var dictionary = new Dictionary<string, JValue>();
            dictionary.Add("id", new JValue("001"));
            dictionary.Add("image.url", new JValue("images / 0001.jpg"));
            dictionary.Add("image.width", new JValue(200));
            dictionary.Add("image.height", new JValue(200));

            txtConverter.GetFields(token).Returns(dictionary);


            var formatedDictionary = new Dictionary<string, JValue>();
            formatedDictionary.Add("\"id\"", new JValue("001"));
            formatedDictionary.Add("\"image\".\"url\"", new JValue("images / 0001.jpg"));
            formatedDictionary.Add("\"image\".\"width\"", new JValue(200));
            formatedDictionary.Add("\"image\".\"height\"", new JValue(200));

            var formater = Substitute.For<IDictionaryFormatter>();

            formater.FormatDictionary(dictionary).Returns(formatedDictionary);

            var centralizer = new CentralizerBuilder()
                                    .WithReader(reader)
                                    .WithDeserializer(deserializer)
                                    .WithJsonToTxtConverter(txtConverter)
                                    .WithFormater(formater)
                                    .Build();

            centralizer.ConvertJsonToTxt("inputPath", "outputPath");

            formater.Received().FormatDictionary(dictionary);
        }

        [TestMethod]
        public void ConvertTxtToJson_ReadMethod_ReceiveCall()
        {
            var reader = Substitute.For<IReader>();
            reader.Read("inputPath").Returns("file");

            var centralizer = new CentralizerBuilder().WithReader(reader).Build();
            centralizer.ConvertTxtToJson("inputPath", "outputPath");

            reader.Received().Read("inputPath");
        }

        [TestMethod]
        public void ConvertTxtToJson_WriteMethod_ReceiveCall()
        {
            var dictionaryWriter = Substitute.For<IDictionaryWriter>();
            var token = new JObject
               (
               new JProperty("id", "001"),
               new JProperty("image",
                   new JObject(new JProperty("url", "images / 0001.jpg"),
                               new JProperty("width", 200),
                               new JProperty("height", 200))));

            var jsonWriter = Substitute.For<IJsonWriter>();
            jsonWriter.Write(token, "outputPath");

            var centralizer = new CentralizerBuilder().WithDictionaryWriter(dictionaryWriter).Build();
            centralizer.ConvertJsonToTxt("inputPath", "outputPath");

            jsonWriter.Received().Write(token, "outputPath");
        }

        [TestMethod]
        public void ConvertTxtToJson_ParseDictionaryMethod_ReceiveCall()
        {
            var reader = Substitute.For<IReader>();
            reader.Read("inputPath").Returns("file");

            var dictionary = new Dictionary<IEnumerable<string>, string>();
            dictionary.Add(new List<string>() { "abc", "def", "egh" }, "value");

            var dictionaryParser = Substitute.For<IDictionaryParser>();
            dictionaryParser.ParseToDictionary("file").Returns(dictionary);

            var centralizer = new CentralizerBuilder()
                .WithReader(reader)
                .WithDictionaryParser(dictionaryParser)
                .Build();
            centralizer.ConvertTxtToJson("inputPath", "outputPath");

            dictionaryParser.Received().ParseToDictionary("file");
        }

        [TestMethod]
        public void ConvertTxtToJson_CreateJsonMethod_ReceiveCall()
        {
            var reader = Substitute.For<IReader>();
            reader.Read("inputPath").Returns("file");

            var dictionary = new Dictionary<IEnumerable<string>, string>();
            dictionary.Add(new List<string>() { "abc", "def", "egh" }, "value");

            var dictionaryParser = Substitute.For<IDictionaryParser>();
            dictionaryParser.ParseToDictionary("file").Returns(dictionary);

            var token = new JObject
              (
              new JProperty("id", "001"),
              new JProperty("image",
                  new JObject(new JProperty("url", "images / 0001.jpg"),
                              new JProperty("width", 200),
                              new JProperty("height", 200))));
 
            var jsonConverter = Substitute.For<ITxtToJsonConverter>();
            jsonConverter.CreateJson(dictionary).Returns(token);

            var centralizer = new CentralizerBuilder()
                .WithReader(reader)
                .WithDictionaryParser(dictionaryParser)
                .WithJsonToTxtConverter(jsonConverter)
                .Build();
            centralizer.ConvertTxtToJson("inputPath", "outputPath");

            jsonConverter.Received().CreateJson(dictionary);
        }
    }
}
