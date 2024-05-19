using automatice_localizaton;

class Program
{
    static void Main()
    {
        string jsSolutionDirectory = "F:\\sampleAbpProject\\RSLog2.0\\src\\Rocscience.RSLog.Web";
        string csSolutionDirectory = "F:\\sampleAbpProject\\RSLog2.0\\src\\Rocscience.RSLog.Web";
        string jsonPath = "C:\\Users\\User\\source\\repos\\automatice-localizaton\\automate-localization\\automatice-localizaton\\en.json";
        
        Dictionary<string, string> stringKeys = Read_json_file.GetKeyValuePair(jsonPath);

        string[] jsFiles = Directory.GetFiles(jsSolutionDirectory, $"*.{"js"}", SearchOption.AllDirectories);
        string[] csFiles = Directory.GetFiles(csSolutionDirectory, $"*.{"cs"}", SearchOption.AllDirectories);

        List<string> csAllUsedLocalizedKey = Read_cshtml_file.GetAllUsedLocalizedKey(csFiles, @"L\[""(.*?)""\]");
        List<string> jsAllUsedLocalizedKey = Read_cshtml_file.GetAllUsedLocalizedKey(jsFiles, @"l\('([^']*)'\)");

        List<string> csMissingKeysInJsonFile = List_dictionary_modifier.GetNonMatchingKeys(csAllUsedLocalizedKey, stringKeys);
        List<string> jsMissingKeysInJsonFile = List_dictionary_modifier.GetNonMatchingKeys(jsAllUsedLocalizedKey, stringKeys);

        foreach (var missedString in csMissingKeysInJsonFile) Console.WriteLine(missedString);
        foreach (var missedString in jsMissingKeysInJsonFile) Console.WriteLine(missedString);

    }

}