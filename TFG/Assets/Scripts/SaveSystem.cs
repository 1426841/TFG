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
                SaveToJson(saveFile);
            }
        }
        else
        {
            SaveToJson(saveFile);   
        }
        
    }

    public SaveFile Load()
    {
        SaveFile saveFile = new SaveFile();
        string json = File.ReadAllText(Application.dataPath + SaveFilePath);

        saveFile = JsonUtility.FromJson<SaveFile>(json);

        return saveFile;
    }

    private void SaveToJson(SaveFile saveFile)
    {
        string json = JsonUtility.ToJson(saveFile);
        File.WriteAllText(Application.dataPath + SaveFilePath, json);
    }
}
