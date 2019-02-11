using FluentAssertions;
using JsonTestApp;
using JsonTestApp.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSubstitute;
using System.Collections.Generic;

namespace JsonTestProject
{
    [TestClass]
    public class JsonToTxtTests
    {
        [TestMethod]
        public void GetFields_JTokenInput_ReturnFormatedKeyValuePair()
        {
            string input = "{\r\n\t\"id\": \"0001\",\r\n\t\"image\":\r\n\t\t{\r\n\t\t\t\"url\": " +
                "\"images/0001.jpg\",\r\n\t\t\t\"width\": 200,\r\n\t\t\t\"height\": 200\r\n\t\t}\r\n}";

            var token = new JObject
                (
                new JProperty("id", "001"),
                new JProperty("image",
                    new JObject(new JProperty("url", "images / 0001.jpg"),
                                new JProperty("width", 200),
                                new JProperty("height", 200))));

            var deserializer = Substitute.For<IDeserializer>();
            deserializer.Deserialize(input).Returns(token);

            var converter = new JsonToTxtBuilder().WithDeserializer(deserializer).Build();

            var expected = new Dictionary<string, JValue>();
            expected.Add("id", new JValue("001"));
            expected.Add("image.url", new JValue("images / 0001.jpg"));
            expected.Add("image.width", new JValue(200));
            expected.Add("image.height", new JValue(200));

            var actual = converter.GetFields(token);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}