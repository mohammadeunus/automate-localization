using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Read_text_file
{
    internal static List<string> GetAllUniqueValues(string txtFilePath)
    {
        // Read all lines from the file
        var lines = File.ReadAllLines(txtFilePath);

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

    private static string GenerateKey(string value)
    {
        // Remove spaces and any other transformations if needed
        return value.Replace(" ", string.Empty);
    }
}
