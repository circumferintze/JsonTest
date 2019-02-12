using FluentAssertions;
using JsonTestApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonTestProject
{
    [TestClass]
    public class DictionaryFormaterTests
    {
        [TestMethod]
        public void FormatDictionary_ValidInput_ReturnCorrectType()
        {
            Dictionary<string, JValue> inputDictionary = new Dictionary<string, JValue>();
            DictionaryFormatter formater = new DictionaryFormatter();

            var actual = formater.FormatDictionary(inputDictionary);

            actual.Should().BeOfType<Dictionary<string, JValue>>();
        }

        [TestMethod]
        public void FormatDictionary_ValidInput_ReturnCorrectFormat()
        {
            Dictionary<string, JValue> inputDictionary = new Dictionary<string, JValue>();
            Dictionary<string, JValue> expected = new Dictionary<string, JValue>();
            inputDictionary.Add("id1.id2", (JValue)1);
            expected.Add("\"id1\".\"id2\"", (JValue)1);
            DictionaryFormatter formater = new DictionaryFormatter();

            var actual = formater.FormatDictionary(inputDictionary);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}