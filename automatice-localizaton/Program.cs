using automatice_localizaton;

class Program
{
    static void Main()
    {
        string solutionDirectory = Console.ReadLine();
        string jsonPath = "D:\\source\\repos\\automate-localization\\automatice-localizaton\\en.json";
        
        Dictionary<string, string> stringKeys = Read_json_file.GetKeyValuePair(jsonPath);

        //string[] jsFiles = Directory.GetFiles(solutionDirectory, $"*.{".js"}", SearchOption.AllDirectories);
        string[] csFiles = Directory.GetFiles(solutionDirectory, $"*.{"cs"}", SearchOption.AllDirectories);

        List<string> allUsedLocalizedKey = Read_cshtml_file.GetAllUsedLocalizedKey(csFiles);

        List<string> missingKeysInJsonFile = List_dictionary_modifier.GetNonMatchingKeys(allUsedLocalizedKey, stringKeys);

        foreach (var projectFile in missingKeysInJsonFile) Console.WriteLine(projectFile);

    }

}