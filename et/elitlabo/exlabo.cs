using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class JsonPlayerPrefs
{
    private string filePath;

    public JsonPlayerPrefs(string filePath)
    {
        this.filePath = filePath;
    }

    public void SetString(string key, string value)
    {
        Dictionary<string, string> data = LoadData();
        data[key] = value;
        SaveData(data);
    }

    public string GetString(string key, string defaultValue = "")
    {
        Dictionary<string, string> data = LoadData();
        if (data.ContainsKey(key))
        {
            return data[key];
        }
        return defaultValue;
    }

    private Dictionary<string, string> LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
        return new Dictionary<string, string>();
    }

    private void SaveData(Dictionary<string, string> data)
    {
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}
