using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    public const string SaveFilePath = "/SaveFile.json";

    [Serializable]
    public class SaveLevel
    {
        public string timerText;
        public float totalTime;
        public int totalCollected;
        public string level;
    }
    [Serializable]
    public class SaveFile
    {
        public List<SaveLevel> saveLevel;
    }

    public void Save()
    {
        SaveLevel saveLevel = new SaveLevel();
        Timer timer = FindObjectOfType<Timer>();
        saveLevel.timerText = timer.GetTimerText();
        saveLevel.totalTime = timer.GetTotalTime();
        Collectables collectables = FindObjectOfType<Collectables>();
        saveLevel.totalCollected = collectables.GetTotalCollected();
        saveLevel.level = SceneManager.GetActiveScene().name;

        SaveFile saveFile = new SaveFile();
        saveFile.saveLevel = new List<SaveLevel>();

        if (File.Exists(Application.dataPath + SaveSystem.SaveFilePath))
        {
            saveFile = Load();
            bool newLevel = true;
            for (int i=0; i < saveFile.saveLevel.Count; i++)
            {
                if(saveLevel.level == saveFile.saveLevel[i].level)
                {
                    newLevel = false;
                    if (saveLevel.totalTime < saveFile.saveLevel[i].totalTime)
                    {
                        saveFile.saveLevel[i].totalTime = saveLevel.totalTime;
                        saveFile.saveLevel[i].timerText = saveLevel.timerText;
                    }

                    if (saveLevel.totalCollected > saveFile.saveLevel[i].totalCollected)
                    {
                        saveFile.saveLevel[i].totalCollected = saveLevel.totalCollected;
                    }
                }
            }

            if (newLevel)
            {
                saveFile.saveLevel.Add(saveLevel);
            }
        } else
        {
            saveFile.saveLevel.Add(saveLevel);
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
