using FluentAssertions;
using JsonTestApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace JsonTestProject
{
    [TestClass]
    public class DictionaryParserTests
    {
        [TestMethod]
        public void ParseToDictionary_ValidInput_ReturnsCorrectType()
        {
            string input = "\"id\"\t0001\r\n\"image\".\"url\"\timages/0001.jpg\r\n\"image\".\"width\"\t200\r\n\"image\".\"height\"\t200\r\n";
            var dictionaryParser = new DictionaryParser(); 

            var result = dictionaryParser.ParseToDictionary(input);

            result.Should().BeOfType<Dictionary<IEnumerable<string>, string>>();
        }

        //[TestMethod]
        //public void ParseToDictionary_ValidInput_ReturnsExpectedDictionary()
        //{
        //    string input = "\"id\"\t0001\r\n\"image\".\"url\"\timages/0001.jpg\r\n\"image\".\"width\"\t200\r\n\"image\".\"height\"\t200\r\n";
        //    var dictionaryParser = new DictionaryParser();

        //    var expected = new Dictionary<IEnumerable<string>, string>();
        //    expected.Add(new List<string>() { "id" }, "001");
        //    expected.Add(new List<string>() { "image", "url" }, "images/0001.jpg");
        //    expected.Add(new List<string>() { "image", "width" }, "200");
        //    expected.Add(new List<string>() { "image", "height" }, "200");

        //    var actual = dictionaryParser.ParseToDictionary(input);

        //    actual.Should().BeEquivalentTo(expected);

        //}
    }
}