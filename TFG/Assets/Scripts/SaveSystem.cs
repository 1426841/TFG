using System;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public const string SaveFilePath = "/SaveFile.json";

    [Serializable]
    public struct SaveFile
    {
        public string timerText;
        public float totalTime;
        public int totalCollected;
    }

    public void Save()
    {
        SaveFile saveFile = new SaveFile();
        Timer timer = FindObjectOfType<Timer>();
        saveFile.timerText = timer.GetTimerText();
        saveFile.totalTime = timer.GetTotalTime();
        Collectables collectables = FindObjectOfType<Collectables>();
        saveFile.totalCollected = collectables.GetTotalCollected();

        if (File.Exists(Application.dataPath + SaveSystem.SaveFilePath))
        {
            SaveFile oldSaveFile = new SaveFile();
            oldSaveFile = Load();

            if (saveFile.totalTime > oldSaveFile.totalTime)
            {
                saveFile.totalTime = oldSaveFile.totalTime;
                saveFile.timerText = oldSaveFile.timerText;
            }

            if (saveFile.totalCollected < oldSaveFile.totalCollected)
            {
                saveFile.totalCollected = oldSaveFile.totalCollected;
            }
        }

        string json = JsonUtility.ToJson(saveFile);
        File.WriteAllText(Application.dataPath + SaveFilePath, json);
    }

    public SaveFile Load()
    {
        SaveFile saveFile = new SaveFile();
        string json = File.ReadAllText(Application.dataPath + SaveFilePath);

        saveFile = JsonUtility.FromJson<SaveFile>(json);

        return saveFile;
    }
}
