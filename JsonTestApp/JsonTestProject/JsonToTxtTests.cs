using JsonTestApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonTestProject
{
    [TestClass]
    public class JsonToTxtTests
    {
        [TestMethod]
        public void GetFields_JTokenInput_RetunrFormatedKeyValuePair()
        {
            string input = "{\r\n\t\"id\": \"0001\",\r\n\t\"image\":\r\n\t\t{\r\n\t\t\t\"url\": " +
                "\"images/0001.jpg\",\r\n\t\t\t\"width\": 200,\r\n\t\t\t\"height\": 200\r\n\t\t}\r\n}";

            JToken jsonToken = JsonConvert.DeserializeObject<JToken>(input);

            JsonToTxtConverter converter = new JsonToTxtConverter();
        }
    }
}