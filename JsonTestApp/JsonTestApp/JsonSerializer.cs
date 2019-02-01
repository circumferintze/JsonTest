using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JsonTestApp
{
    public class JSONSerializer
    {
        private List<string> list;
        private JObject json;

        public JSONSerializer()
        {
            list = new List<string>();
            json = new JObject();
        }

        public void Serialize()
        {
            string filePath = System.IO.Path.GetFullPath("output.txt");

            string input;
            using (StreamReader r = new StreamReader(filePath))
            {
                input = r.ReadToEnd();
            }

            var inputArray = input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputArray.Length; ++i)
            {
                var path = inputArray[i].Split(':')[i];
                var keys = path.Split('.');
                var value = inputArray[i].Split(':')[i+1];
            }



            //for (int i = 0; i < value.Length; i++)
            //{
            //    if (value[i].Contains("."))
            //    {
            //        var temp1 = value[i].Substring(0, value[i].IndexOf("."));
            //        var temp2 = value[i+1].Substring(0, value[i+1].IndexOf("."));
            //        if (temp1 == temp2)
            //        {
            //            // json.Add(new JProperty(temp));
            //            value[i] = value[i].Replace(temp1, "").TrimStart('.');
            //        }
            //        //Iterator(result);
            //    }
            //}

            //var t = 1;
        }

        //public JObject Iterator(string[] value)
        //{
        //    for (int i = 0; i < value.Length; i++)
        //    {
        //        var temp = value[i].Substring(0, value[i].IndexOf("."));
        //        value[i] = value[i].Replace(temp, "").TrimStart('.');
        //    }

        //    return new JObject(temp, Iterator(value));
        //}
    }
}