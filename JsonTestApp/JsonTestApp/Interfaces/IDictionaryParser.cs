using System.Collections.Generic;

namespace JsonTestApp.Interfaces
{
    public interface IDictionaryParser
    {
        Dictionary<IEnumerable<string>, string> ParseToDictionary(string file);
    }
}