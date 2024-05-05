using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace automatice_localizaton;

public static class Read_json_file
{
    public static Dictionary<string, string> GetKeyValuePair(string filePath)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        try
        {
            string jsonString = File.ReadAllText(filePath);

            data = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return data;
    }

}
