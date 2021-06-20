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
                // If the current level has been completed before, 
                // compares the values saved in the saveFile with the new values
                if (saveLevel.level == saveFile.saveLevel[i].level)
                {
                    newLevel = false;
                    // If saveLevel has less time, saves the new value
                    if (saveLevel.totalTime < saveFile.saveLevel[i].totalTime)
                    {
                        saveFile.saveLevel[i].totalTime = saveLevel.totalTime;
                        saveFile.saveLevel[i].timerText = saveLevel.timerText;
                    }

                    // If saveLevel has more collectables collected, saves the new value
                    if (saveLevel.totalCollected > saveFile.saveLevel[i].totalCollected)
                    {
                        saveFile.saveLevel[i].totalCollected = saveLevel.totalCollected;
                    }
                }
            }

            // If the current level has been completed for the first time, 
            // saves the new values directly without checking the values in the saveFile
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

    public int GetCompletedLevels()
    {
        if (File.Exists(Application.dataPath + SaveSystem.SaveFilePath))
        {
            SaveFile saveFile = Load();
            return saveFile.saveLevel.Count;
        }
        else
        {
            return 0;
        } 
    }

    public string GetLevelTime(int level)
    {
        string levelTime = Timer.DefaultTime;
        if (File.Exists(Application.dataPath + SaveSystem.SaveFilePath))
        {
            SaveFile saveFile = Load();

            // Checks if the level has already been completed
            if (level <= saveFile.saveLevel.Count)
            {
                return saveFile.saveLevel[level-1].timerText;
            }
        }
        return levelTime;
    }

    public string GetLevelTotalCollected(int level)
    {
        string levelCollected = "0";
        if (File.Exists(Application.dataPath + SaveSystem.SaveFilePath))
        {
            SaveFile saveFile = Load();

            // Checks if the level has already been completed
            if (level <= saveFile.saveLevel.Count)
            {
                return saveFile.saveLevel[level-1].totalCollected.ToString();
            }
        }
        return levelCollected;
    }
}
