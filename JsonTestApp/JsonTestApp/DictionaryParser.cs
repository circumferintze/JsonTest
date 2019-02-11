using JsonTestApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonTestApp
{
    public class DictionaryParser : IDictionaryParser
    {
        public Dictionary<IEnumerable<string>, string> ParseToDictionary(string file)
        {
            var inputList = file.Replace("\"", "").Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var dictionary = inputList.Select(x => x.Split('\t'))
                              .GroupBy(x => x[0].Split(new string[] { @"." }, StringSplitOptions.RemoveEmptyEntries))
                              .ToDictionary(x => x.Key.AsEnumerable(), x => x.Select(g => g[1]).Distinct().FirstOrDefault());

            return dictionary;
        }
    }
}