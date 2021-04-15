using System;
using UnityEngine;

public class SaveSystem
{
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
        System.IO.File.WriteAllText(Application.dataPath + "/SaveFile.json", json);
    }
}
