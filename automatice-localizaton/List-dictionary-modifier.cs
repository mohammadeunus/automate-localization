


using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

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
        List<string> notFoundStrings = new();
        foreach (string eachStr in fileStrings)
        {
            // Check if the value exists in the dictionary
            KeyValuePair<string, string> foundMatchingPair = stringKeys.FirstOrDefault(x => x.Value == eachStr);
            if (!string.IsNullOrEmpty(foundMatchingPair.Key) && !matchedKeys.ContainsKey(foundMatchingPair.Key))
            {
                matchedKeys.Add(foundMatchingPair.Key, foundMatchingPair.Value);
            }
            else if (string.IsNullOrEmpty(foundMatchingPair.Key) && !ContainsRegularExpression(eachStr))
            {
                notFoundStrings.Add(eachStr);
            }
        }
        if (notFoundStrings.Count>0)
        {
            GenerateJsonFileforStringNotInEnJson(notFoundStrings);
        }
        return matchedKeys;
    }

    private static void GenerateJsonFileforStringNotInEnJson(List<string> notFoundStrings)
    {
        foreach (var item in notFoundStrings)
        {
            string output = "\"" + ConvertToCamelCase(item) + "\"" + ":"+ "\"" + item + "\"";
            Console.WriteLine(output + ",");
        }
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

    private static string ConvertToCamelCase(string input)
    {
        string[] words = input.Split(' ');

        StringBuilder sb = new StringBuilder();

        foreach (string word in words)
        {
            sb.Append(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word));
        }

        return sb.ToString();
    }
    static bool ContainsRegularExpression(string input)
    {
        string regexPattern = @"[*+^${}()|\[\]\\]";

        bool check =  Regex.IsMatch(input, regexPattern);
        bool check2 =  Regex.IsMatch(input, "@");
        bool check3 =  input.Equals("/");
        bool check4 =  input.Equals("&Times");

        return check || check2 || check3 || check4;
    }
}
