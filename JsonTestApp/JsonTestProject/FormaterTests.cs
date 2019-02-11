using FluentAssertions;
using JsonTestApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestProject
{
    [TestClass]
    public class FormaterTests
    {
        [TestMethod]
        public void FormatDictionary_ValidInput_ReturnCorrectFormat()
        {
            Dictionary<string, JValue> inputDictionary = new Dictionary<string, JValue>();
            Dictionary<string, JValue> expected = new Dictionary<string, JValue>();
            inputDictionary.Add("id1.id2", (JValue)1);
            expected.Add("\"id1\".\"id2\"", (JValue)1);
            Formater formater = new Formater();

            var actual = formater.FormatDictionary(inputDictionary);

            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void FormatPath_ValidInput_ReturnCorrectFormat()
        {
            string inputPath = "a1[a2]";
            string expected = "a1.a2";
            Formater formater = new Formater();

            var actual = formater.FormatPath(inputPath);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}