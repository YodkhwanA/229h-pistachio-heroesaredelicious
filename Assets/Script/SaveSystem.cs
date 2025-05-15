using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string saveFilePath = Application.persistentDataPath + "/savefile.json";

    public static void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
    }

    public static SaveData Load()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            return JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            return new SaveData();
        }
    }

    public static int LoadLevel()
    {
        SaveData data = Load();
        return data.UnlockedLevel;
    }
}

