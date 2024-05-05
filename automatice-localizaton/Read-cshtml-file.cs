using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace automatice_localizaton;

internal class Read_cshtml_file
{
    internal static List<string> ExtractStringsFromCSHTML(string filePath)
    {
        List<string> strings = new List<string>();

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null || string.IsNullOrEmpty(line))
                {
                    MatchCollection matches = Regex.Matches(line, @">(.*?)<");
                    foreach (Match match in matches)
                    {
                        string output = match.Groups[1].Value.Trim();
                        if (!ContainsRegularExpression(output) && !string.IsNullOrEmpty(output))
                        {
                            strings.Add(output);
                        }

                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return strings;
    }
    static bool ContainsRegularExpression(string input)
    {
        string regexPattern = @"[.*+?^${}()|\[\]\\]";

        return Regex.IsMatch(input, regexPattern);
    }
}
