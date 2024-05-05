using automatice_localizaton;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string filePath = "F:\\sampleAbpProject\\RSLog2.0\\src\\Rocscience.RSLog.Web\\Pages\\Boreholes\\Manage\\Stratigraphy\\Components\\USCS\\Default.cshtml";
        string jsonPath = "F:\\sampleAbpProject\\RSLog2.0\\src\\Rocscience.RSLog.Domain.Shared\\Localization\\RSLog\\en.json";

        List<string> strings = Read_cshtml_file.ExtractStringsFromCSHTML(filePath);
        Dictionary<string, string> stringKeys = Read_json_file.GetKeyValuePair(jsonPath);

        Console.WriteLine(stringKeys.Count);
        Console.WriteLine(strings.Count);

    }


}
