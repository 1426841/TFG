using System;
using System.IO;
using UnityEngine;

public class SaveSystem
{
    public const string SaveFilePath = "/SaveFile.json";

    [Serializable]
    private struct SaveFile
    {
        public string time;
    }

    public void Save(string time)
    {
        SaveFile saveFile = new SaveFile();
        saveFile.time = time;

        string json = JsonUtility.ToJson(saveFile);
        File.WriteAllText(Application.dataPath + SaveFilePath, json);
    }
}
