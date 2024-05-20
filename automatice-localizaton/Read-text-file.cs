using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Read_text_file
{
    internal static List<string> GetAllUniqueValues(string txtFilePath)
    {
        if (string.IsNullOrEmpty(txtFilePath))
        {
            throw new ArgumentException("File path cannot be null or empty.", nameof(txtFilePath));
        }

        if (!File.Exists(txtFilePath))
        {
            throw new FileNotFoundException("File not found.", txtFilePath);
        }

        // Read all lines from the file
        var lines = File.ReadAllLines(txtFilePath);

        // Use a dictionary to store unique values
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

        // Convert dictionary entries to the expected output format
        var formattedList = uniqueValues.Select(kvp => $"\"{kvp.Key}\" : \"{kvp.Value}\"").ToList();
        return formattedList;
    }

    private static string GenerateKey(string value)
    {
        // Remove spaces and any other transformations if needed
        return value.Replace(" ", string.Empty);
    }
}
