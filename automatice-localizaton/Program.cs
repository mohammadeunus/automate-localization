using automatice_localizaton;

class Program
{
    static void Main()
    {
        string csSolutionDirectory = "F:\\sampleAbpProject\\RSLog2.0\\src\\Rocscience.RSLog.Web";
        string jsonPath = "C:\\Users\\User\\source\\repos\\automatice-localizaton\\automate-localization\\automatice-localizaton\\files\\en.json";
        string txtFilePath = "C:\\Users\\User\\source\\repos\\automatice-localizaton\\automate-localization\\automatice-localizaton\\files\\rslogmissedkeys.txt";
        
        Dictionary<string, string> stringKeys = Read_json_file.GetKeyValuePair(jsonPath);

        string[] csFiles = Directory.GetFiles(csSolutionDirectory, $"*.{"cshtml"}", SearchOption.AllDirectories);

        // get values as list in txtList
        List<string> txtList = Read_text_file.GetAsList(txtFilePath);

        // remove duplicate from the txtList

        // remove matching value with stringKeys from the txtList

        // generate unique key from the txtList
        List<string> UniqueValues = Read_text_file.GetAllUniqueValues(txtList); 
        
        foreach (var missedString in UniqueValues) Console.WriteLine(missedString);
    }

}