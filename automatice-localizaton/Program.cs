using automatice_localizaton;

class Program
{
    static void Main()
    {
        string filePath = "F:\\sampleAbpProject\\RSLog2.0\\src\\Rocscience.RSLog.Web\\Pages\\Boreholes\\Manage\\Stratigraphy\\InnerGridsCreateOrUpdateModals\\CreateOrUpdateRockInterimModal.cshtml";
        string jsonPath = "C:\\Users\\User\\source\\repos\\automatice-localizaton\\automate-localization\\automatice-localizaton\\en.json";

        List<string> strings = Read_cshtml_file.ExtractStringsFromCSHTML(filePath);
        Dictionary<string, string> stringKeys = Read_json_file.GetKeyValuePair(jsonPath);

        Dictionary<string, string> matchedKeys = List_dictionary_modifier.GetMatchedKeyValues(strings, stringKeys);

        Console.WriteLine(matchedKeys);
        Read_cshtml_file.OverrideFile(filePath, matchedKeys);

    }

}