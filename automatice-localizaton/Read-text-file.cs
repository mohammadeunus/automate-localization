using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Read_text_file
{
    internal static List<string> GetAllUniqueValues(List<string> lines)
    {
        var uniqueValues = new Dictionary<string, string>();

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();

            if (!string.IsNullOrEmpty(trimmedLine) && !uniqueValues.ContainsValue(trimmedLine))
            {
                var key = GenerateKey(trimmedLine);
                uniqueValues[key] = trimmedLine;
            }
        }

        var formattedList = uniqueValues.Select(kvp => $"\"{kvp.Key}\" : \"{kvp.Value}\"").ToList();
        return formattedList;
    }

    internal static List<string> GetAsList(string txtFilePath)
    {
        var lines = File.ReadAllLines(txtFilePath);
        return lines.ToList();
    }

    private static string GenerateKey(string value)
    {
        // Remove spaces and any other transformations if needed
        return value.Replace(" ", string.Empty);
    }
}
