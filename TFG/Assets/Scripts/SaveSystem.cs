using System;
using System.IO;
using UnityEngine;

public class SaveSystem
{
    public const string SaveFilePath = "/SaveFile.json";

    [Serializable]
    public struct SaveFile
    {
        public string time;
        public float totalTime;
    }

    public void Save(string time, float totalTime)
    {
        SaveFile saveFile = new SaveFile();
        saveFile.time = time;
        saveFile.totalTime = totalTime;

        if (File.Exists(Application.dataPath + SaveSystem.SaveFilePath))
        {
            SaveFile oldSaveFile = new SaveFile();
            oldSaveFile = Load();

            if(saveFile.totalTime < oldSaveFile.totalTime)
            {
                string json = JsonUtility.ToJson(saveFile);
                File.WriteAllText(Application.dataPath + SaveFilePath, json);
            }
        }
        else
        {
            
            string json = JsonUtility.ToJson(saveFile);
            File.WriteAllText(Application.dataPath + SaveFilePath, json);
        }
        
    }

    public SaveFile Load()
    {
        SaveFile saveFile = new SaveFile();
        string json = File.ReadAllText(Application.dataPath + "/SaveFile.json");

        saveFile = JsonUtility.FromJson<SaveFile>(json);

        return saveFile;
    }
}
