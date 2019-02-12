using FluentAssertions;
using JsonTestApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestProject
{
    [TestClass]
    public class JsonToTxtTests
    {
        [TestMethod]
        public void GetFields_JTokenInput_ReturnFormatedKeyValuePair()
        {
            var token = new JObject
                (
                new JProperty("id", "001"),
                new JProperty("image",
                    new JObject(new JProperty("url", "images / 0001.jpg"),
                                new JProperty("width", 200),
                                new JProperty("height", 200))));

            var converter = new JsonToTxtConverter();

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