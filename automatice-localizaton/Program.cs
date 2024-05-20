using automatice_localizaton;

class Program
{
    static void Main()
    {
        string csSolutionDirectory = "F:\\sampleAbpProject\\RSLog2.0\\src\\Rocscience.RSLog.Web";
        string jsonPath = "C:\\Users\\User\\source\\repos\\automatice-localizaton\\automate-localization\\automatice-localizaton\\en.json";
        
        Dictionary<string, string> stringKeys = Read_json_file.GetKeyValuePair(jsonPath);

        string[] cshtmlFiles = Directory.GetFiles(csSolutionDirectory, $"*.{"cshtml"}", SearchOption.AllDirectories);

        foreach (var filePath in cshtmlFiles)
        {
            Read_cshtml_file.OverrideInLocalizedString(filePath, stringKeys);
        }
    }

}