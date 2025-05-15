using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/savefile.json";

    public static void SaveLevel(int level)
    {
        SaveData data = new SaveData();
        data.currentLevel = level;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Saved level: " + level);
    }

    public static int LoadLevel()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Loaded level: " + data.currentLevel);
            return data.currentLevel;
        }
        else
        {
            Debug.LogWarning("No save file found, returning level 1");
            return 1;
        }
    }
}

