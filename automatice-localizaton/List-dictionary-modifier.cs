 

namespace automatice_localizaton;

internal static class List_dictionary_modifier
{
    public static List<string> GetMatchedKeys(List<string> fileStrings, Dictionary<string, string> stringKeys)
    {
        List<string> matchedKeys = new List<string>();
        foreach (string str in fileStrings)
        {
            // Check if the value exists in the dictionary
            KeyValuePair<string, string> matchingPair = stringKeys.FirstOrDefault(x => x.Value == str);
            if (!string.IsNullOrEmpty(matchingPair.Key))
            {
                matchedKeys.Add(matchingPair.Key);
            } 
        }
        return matchedKeys;
    }
    public static Dictionary<string, string> GetMatchedKeyValues(List<string> fileStrings, Dictionary<string, string> stringKeys)
    {
        Dictionary<string, string> matchedKeys = new Dictionary<string, string>();
        foreach (string str in fileStrings)
        {
            // Check if the value exists in the dictionary
            KeyValuePair<string, string> matchingPair = stringKeys.FirstOrDefault(x => x.Value == str);
            if (!string.IsNullOrEmpty(matchingPair.Key) && !matchedKeys.ContainsKey(matchingPair.Key))
            {
                matchedKeys.Add(matchingPair.Key, matchingPair.Value);
            }
        }
        return matchedKeys;
    }
    public static List<string> GetNonMatchedKeys(List<string> fileStrings, Dictionary<string,string> stringKeys)
    {
        List<string> nonMatchedKeys = new List<string>();
        foreach (string str in fileStrings)
        {
            // Check if the value exists in the dictionary
            KeyValuePair<string, string> matchingPair = stringKeys.FirstOrDefault(x => x.Value == str);
            if (string.IsNullOrEmpty(matchingPair.Key))
            {
                nonMatchedKeys.Add(matchingPair.Key);
            }
        }
        return nonMatchedKeys;
    }
}
