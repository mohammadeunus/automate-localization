using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                        string output = match.Groups[1].Value;
                        if (!string.IsNullOrEmpty(output)) output = output.Trim();

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
        string regexPattern = @"[*+^${}()|\[\]\\]";

        return Regex.IsMatch(input, regexPattern);
    }

    public static void OverrideFile(string filePath, Dictionary<string, string> matchedKeys)
    {
        try
        {
            // Read all lines from the file
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            // Create a StreamWriter to write to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string line in lines)
                {
                    string modifiedLine = line;

                    MatchCollection matches = Regex.Matches(line, @">(.*?)<");
                    foreach (Match match in matches)
                    {
                        string output = match.Groups[1].Value;
                        if (!string.IsNullOrEmpty(output)) output = output.Trim();

                        if (!ContainsRegularExpression(output) && !string.IsNullOrEmpty(output))
                        {
                            foreach (KeyValuePair<string, string> entry in matchedKeys)
                            {
                                if (entry.Value.Equals(output))
                                {
                                    string theString = '@' + "L[\"" + entry.Key + "\"]";
                                    modifiedLine = line.Replace(entry.Value, theString);
                                    break;
                                }
                            }
                        }


                    }

                    writer.WriteLine(modifiedLine);
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("File override successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error overriding file: {ex.Message}");
        }
    }
    public static void OverrideJsFile(string filePath, Dictionary<string, string> matchedKeys)
    {
        try
        {
            // Read all lines from the file
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            // Create a StreamWriter to write to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string line in lines)
                {
                    string modifiedLine = line;

                    foreach (KeyValuePair<string, string> entry in matchedKeys)
                    {
                        if (Regex.IsMatch(line, entry.Value))
                        {
                            string theString = "l(\'" + entry.Key + "\')";
                            modifiedLine = line.Replace(entry.Value, theString);
                            break;
                        }
                    }

                    writer.WriteLine(modifiedLine);
                }
            }
            Console.WriteLine("File override successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error overriding file: {ex.Message}");
        }
    }

    internal static List<string> GetAllUsedLocalizedKey(string[] csFiles, string regextPattern)
    {
        List<string> missingKeyInJsonFile = [];

        foreach (var csFilePath in csFiles)
        {
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(csFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            List<string> extractedStrings = new List<string>();

            foreach (string line in lines)
            {
                MatchCollection matches = Regex.Matches(line, regextPattern);
                foreach (Match match in matches)
                {
                    string extractedString = match.Groups[1].Value;
                    extractedStrings.Add(extractedString);
                }
            }

            missingKeyInJsonFile.AddRange(extractedStrings);
            missingKeyInJsonFile.Add("-------------------");
        }

        return missingKeyInJsonFile;
    }
}
