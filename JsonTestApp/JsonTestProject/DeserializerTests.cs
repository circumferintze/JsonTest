using FluentAssertions;
using JsonTestApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace JsonTestProject
{
    [TestClass]
    public class DeserializerTests
    {
        [TestMethod]
        public void Deserialize_ValidInput_JObjectType()
        {
            string input = "{\r\n\t\"id\": \"0001\",\r\n\t\"image\":\r\n\t\t{\r\n\t\t\t\"url\": " +
                "\"images/0001.jpg\",\r\n\t\t\t\"width\": 200,\r\n\t\t\t\"height\": 200\r\n\t\t}\r\n}";

            var deserializer = new Deserializer();
            var result = deserializer.Deserialize(input);

            result.Should().BeOfType<JObject>();
        }

        [TestMethod]
        public void Deserialize_ValidInput_ReturnJObject()
        {
            string input = "{\r\n\t\"id\": \"0001\",\r\n\t\"image\":\r\n\t\t{\r\n\t\t\t\"url\": " +
                "\"images/0001.jpg\",\r\n\t\t\t\"width\": 200,\r\n\t\t\t\"height\": 200\r\n\t\t}\r\n}";
            var expected = new JObject
                (
                new JProperty("id", "001"),
                new JProperty("image",
                    new JObject(new JProperty("url", "images / 0001.jpg"),
                                new JProperty("width", 200),
                                new JProperty("height", 200))));

            var deserializer = new Deserializer();
            var actual = deserializer.Deserialize(input);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}