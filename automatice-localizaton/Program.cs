using automatice_localizaton;

class Program
{
    static void Main()
    {
        string csSolutionDirectory = "D:\\source\\repos\\RSLog2.0\\src\\Rocscience.RSLog.Application";
        string jsSolutionDirectory = "D:\\source\\repos\\RSLog2.0\\src\\Rocscience.RSLog.Web\\Pages";
        string jsonPath = "D:\\source\\repos\\automate-localization\\automatice-localizaton\\en.json";
        
        Dictionary<string, string> stringKeys = Read_json_file.GetKeyValuePair(jsonPath);

        string[] jsFiles = Directory.GetFiles(jsSolutionDirectory, $"*.{"js"}", SearchOption.AllDirectories);
        string[] csFiles = Directory.GetFiles(csSolutionDirectory, $"*.{"cs"}", SearchOption.AllDirectories);

        List<string> csAllUsedLocalizedKey = Read_cshtml_file.GetAllUsedLocalizedKey(csFiles, @"L\[""(.*?)""\]");
        List<string> jsAllUsedLocalizedKey = Read_cshtml_file.GetAllUsedLocalizedKey(jsFiles, @"l\('([^']*)'\)");

        List<string> csMissingKeysInJsonFile = List_dictionary_modifier.GetNonMatchingKeys(csAllUsedLocalizedKey, stringKeys);
        List<string> jsMissingKeysInJsonFile = List_dictionary_modifier.GetNonMatchingKeys(jsAllUsedLocalizedKey, stringKeys);

        foreach (var projectFile in csMissingKeysInJsonFile) Console.WriteLine(projectFile);
        foreach (var projectFile in jsMissingKeysInJsonFile) Console.WriteLine(projectFile);

    }

}