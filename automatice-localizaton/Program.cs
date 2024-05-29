using automatice_localizaton;

class Program
{
    static void Main()
    {
        string solutionDirectory = "F:\\sampleAbpProject\\RSLog2.0\\src\\Rocscience.RSLog.Web\\Themes\\";
        string jsonPath = "C:\\Users\\User\\source\\repos\\automatice-localizaton\\automate-localization\\automatice-localizaton\\en.json";
        
        Dictionary<string, string> stringKeys = Read_json_file.GetKeyValuePair(jsonPath);

        string[] csFiles = Directory.GetFiles(solutionDirectory, $"*.{"cshtml"}", SearchOption.AllDirectories);

        List<string> csMissingKeysInJsonFile = Read_cshtml_file.GetNotLocalizedStringKeyValuePair(csFiles, stringKeys);

        foreach (var missedString in csMissingKeysInJsonFile) Console.WriteLine(missedString);
    }

}