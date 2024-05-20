using automatice_localizaton;

class Program
{
    static void Main()
    {
        string filePath = "F:\\sampleAbpProject\\RSLog2.0\\src\\Rocscience.RSLog.Web\\Pages";
        string jsonPath = "C:\\Users\\User\\source\\repos\\automatice-localizaton\\automate-localization\\automatice-localizaton\\en.json";

        Dictionary<string, string> stringKeys = Read_json_file.GetKeyValuePair(jsonPath);

        Read_cshtml_file.OverrideFile(filePath, stringKeys);
    }

}