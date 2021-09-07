using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveLoad
{
    public static string directory = "/SaveData/";
    public static string fileName = "KukaData.txt";

    public static void Save(SaveData actions)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(actions, true);
        File.WriteAllText(dir + fileName, json);
    }

    public static SaveData Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveData actions = new SaveData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            actions = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            Debug.Log("SaveFile doesn't exist!");
        }

        return actions;
    }
}
