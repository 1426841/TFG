using System.Collections;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class SaveSystemTests
    {
        [UnityTest]
        public IEnumerator Save()
        {
            var gameObject = new GameObject();
            var saveSystem = gameObject.AddComponent<SaveSystem>();
            saveSystem.gameObject.AddComponent<Timer>();
            saveSystem.gameObject.AddComponent<Text>();
            saveSystem.gameObject.AddComponent<Collectables>();

            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
            Assert.IsFalse(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));

            yield return null;
            saveSystem.Save();
            Assert.IsTrue(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));
            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
        }
        
        [UnityTest]
        public IEnumerator Load()
        {
            var gameObject = new GameObject();
            var saveSystem = gameObject.AddComponent<SaveSystem>();
            saveSystem.gameObject.AddComponent<Timer>();
            saveSystem.gameObject.AddComponent<Text>();

            var gameObjectCollect = new GameObject();
            var collectables = gameObjectCollect.AddComponent<Collectables>();
            collectables.gameObject.AddComponent<Text>();

            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);

            //New File: Time=1 Collected=0
            yield return new WaitForSeconds(1);
            saveSystem.Save();
            SaveSystem.SaveFile saveFile = new SaveSystem.SaveFile();
            saveFile = saveSystem.Load();
            Assert.AreEqual(saveFile.saveLevel[0].timerText, "0:1,0");
            Assert.AreEqual(saveFile.saveLevel[0].totalTime.ToString("f1"), "1,0");
            Assert.AreEqual(saveFile.saveLevel[0].totalCollected, 0);

            //Only updates collected: Time=2 Collected=1
            yield return new WaitForSeconds(1);
            collectables.gameObject.GetComponent<Collectables>().Collect();
            saveSystem.Save();
            saveFile = saveSystem.Load();
            Assert.AreEqual(saveFile.saveLevel[0].timerText, "0:1,0");
            Assert.AreEqual(saveFile.saveLevel[0].totalTime.ToString("f1"), "1,0");
            Assert.AreEqual(saveFile.saveLevel[0].totalCollected, 1);

            //Only updates time: Time=0,9 Collected=1
            saveSystem.gameObject.GetComponent<Timer>().ResetTime();
            yield return new WaitForSeconds(0.9f);
            saveSystem.Save();
            saveFile = saveSystem.Load();
            Assert.AreEqual(saveFile.saveLevel[0].timerText, "0:0,9");
            Assert.AreEqual(saveFile.saveLevel[0].totalTime.ToString("f1"), "0,9");
            Assert.AreEqual(saveFile.saveLevel[0].totalCollected, 1);

            //Updates time and collected: Time=0,5 Collected=2
            saveSystem.gameObject.GetComponent<Timer>().ResetTime();
            yield return new WaitForSeconds(0.5f);
            collectables.gameObject.GetComponent<Collectables>().Collect();
            saveSystem.Save();
            saveFile = saveSystem.Load();
            Assert.AreEqual(saveFile.saveLevel[0].timerText, "0:0,5");
            Assert.AreEqual(saveFile.saveLevel[0].totalTime.ToString("f1"), "0,5");
            Assert.AreEqual(saveFile.saveLevel[0].totalCollected, 2);

            //Doesn't update anything: Time=0,6 Collected=2
            yield return new WaitForSeconds(0.1f);
            saveSystem.Save();
            saveFile = saveSystem.Load();
            Assert.AreEqual(saveFile.saveLevel[0].timerText, "0:0,5");
            Assert.AreEqual(saveFile.saveLevel[0].totalTime.ToString("f1"), "0,5");
            Assert.AreEqual(saveFile.saveLevel[0].totalCollected, 2);

            SceneManager.LoadScene("Lvl1");
            yield return null;

            var saveSystemGameObject = new GameObject();
            var Lvl1SaveSystem = saveSystemGameObject.AddComponent<SaveSystem>();
            Lvl1SaveSystem.gameObject.AddComponent<Timer>();
            Lvl1SaveSystem.gameObject.AddComponent<Text>();

            var CollectGameObject = new GameObject();
            var Lvl1Collectables = CollectGameObject.AddComponent<Collectables>();
            Lvl1Collectables.gameObject.AddComponent<Text>();

            //Lvl1 saved in different saveLevel: Time=1 Collected=1
            Lvl1SaveSystem.gameObject.GetComponent<Timer>().ResetTime();
            yield return new WaitForSeconds(1f);
            Lvl1Collectables.gameObject.GetComponent<Collectables>().Collect();
            Lvl1SaveSystem.Save();
            saveFile = Lvl1SaveSystem.Load();
            Assert.AreEqual(saveFile.saveLevel[0].timerText, "0:0,5");
            Assert.AreEqual(saveFile.saveLevel[0].totalTime.ToString("f1"), "0,5");
            Assert.AreEqual(saveFile.saveLevel[0].totalCollected, 2);
            Assert.AreEqual(saveFile.saveLevel[1].timerText, "0:1,0");
            Assert.AreEqual(saveFile.saveLevel[1].totalTime.ToString("f1"), "1,0");
            Assert.AreEqual(saveFile.saveLevel[1].totalCollected, 1);
            Assert.AreEqual(saveFile.saveLevel[1].level, "Lvl1");

            //Only updates Lvl1 saveLevel: Time=0,4 Collected=3
            Lvl1SaveSystem.gameObject.GetComponent<Timer>().ResetTime();
            yield return new WaitForSeconds(0.4f);
            Lvl1Collectables.gameObject.GetComponent<Collectables>().Collect();
            Lvl1Collectables.gameObject.GetComponent<Collectables>().Collect();
            Lvl1SaveSystem.Save();
            saveFile = Lvl1SaveSystem.Load();
            Assert.AreEqual(saveFile.saveLevel[0].timerText, "0:0,5");
            Assert.AreEqual(saveFile.saveLevel[0].totalTime.ToString("f1"), "0,5");
            Assert.AreEqual(saveFile.saveLevel[0].totalCollected, 2);
            Assert.AreEqual(saveFile.saveLevel[1].timerText, "0:0,4");
            Assert.AreEqual(saveFile.saveLevel[1].totalTime.ToString("f1"), "0,4");
            Assert.AreEqual(saveFile.saveLevel[1].totalCollected, 3);
            Assert.AreEqual(saveFile.saveLevel[1].level, "Lvl1");

            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
        }

        [UnityTest]
        public IEnumerator GetLevelTime()
        {
            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);

            SceneManager.LoadScene("Lvl1");
            yield return null;

            var gameObject = new GameObject();
            var saveSystem = gameObject.AddComponent<SaveSystem>();
            saveSystem.gameObject.AddComponent<Timer>();
            saveSystem.gameObject.AddComponent<Text>();
            saveSystem.gameObject.AddComponent<Collectables>();

            Assert.AreEqual(saveSystem.GetLevelTime(1), Timer.defaultTime);
            Assert.AreEqual(saveSystem.GetLevelTime(2), Timer.defaultTime);

            yield return new WaitForSeconds(0.2f);
            saveSystem.Save();

            Assert.AreEqual(saveSystem.GetLevelTime(1), "0:0,2");
            Assert.AreEqual(saveSystem.GetLevelTime(2), Timer.defaultTime);

            saveSystem.gameObject.GetComponent<Timer>().ResetTime();

            yield return new WaitForSeconds(0.1f);
            saveSystem.Save();

            Assert.AreEqual(saveSystem.GetLevelTime(1), "0:0,1");
            Assert.AreEqual(saveSystem.GetLevelTime(2), Timer.defaultTime);

            SceneManager.LoadScene("Lvl2");
            yield return new WaitForSeconds(0.2f);
            saveSystem.Save();

            Assert.AreEqual(saveSystem.GetLevelTime(1), "0:0,1");
            Assert.AreEqual(saveSystem.GetLevelTime(2), "0:0,2");

            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
        }
    }
}
