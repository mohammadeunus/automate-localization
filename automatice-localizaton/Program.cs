using automatice_localizaton;

class Program
{
    static void Main()
    {
        string filePath = Console.ReadLine();
        string jsonPath = "C:\\Users\\User\\source\\repos\\automatice-localizaton\\automate-localization\\automatice-localizaton\\en.json";

        #region abstract
        Dictionary<string, string> stringKeys = Read_json_file.GetKeyValuePair(jsonPath);

        List<string> strings = Read_cshtml_file.ExtractStringsFromCSHTML(filePath);
        List_dictionary_modifier.GetMatchedKeyValues(strings, stringKeys);
        #endregion

        Read_cshtml_file.OverrideFile(filePath, stringKeys);

    }

}