using System.Collections;
using System.IO;
using NUnit.Framework;
using UnityEngine;
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
            Assert.AreEqual(saveFile.timerText, "0:1,0");
            Assert.AreEqual(saveFile.totalTime.ToString("f1"), "1,0");
            Assert.AreEqual(saveFile.totalCollected, 0);

            //Only updates collected: Time=2 Collected=1
            yield return new WaitForSeconds(1);
            collectables.gameObject.GetComponent<Collectables>().Collect();
            saveSystem.Save();
            saveFile = saveSystem.Load();
            Assert.AreEqual(saveFile.timerText, "0:1,0");
            Assert.AreEqual(saveFile.totalTime.ToString("f1"), "1,0");
            Assert.AreEqual(saveFile.totalCollected, 1);

            //Only updates time: Time=0,9 Collected=1
            saveSystem.gameObject.GetComponent<Timer>().ResetTime();
            yield return new WaitForSeconds(0.9f);
            saveSystem.Save();
            saveFile = saveSystem.Load();
            Assert.AreEqual(saveFile.timerText, "0:0,9");
            Assert.AreEqual(saveFile.totalTime.ToString("f1"), "0,9");
            Assert.AreEqual(saveFile.totalCollected, 1);

            //Updates time and collected: Time=0,5 Collected=2
            saveSystem.gameObject.GetComponent<Timer>().ResetTime();
            yield return new WaitForSeconds(0.5f);
            collectables.gameObject.GetComponent<Collectables>().Collect();
            saveSystem.Save();
            saveFile = saveSystem.Load();
            Assert.AreEqual(saveFile.timerText, "0:0,5");
            Assert.AreEqual(saveFile.totalTime.ToString("f1"), "0,5");
            Assert.AreEqual(saveFile.totalCollected, 2);

            //Doesn't update anything: Time=0,6 Collected=2
            yield return new WaitForSeconds(0.1f);
            saveSystem.Save();
            saveFile = saveSystem.Load();
            Assert.AreEqual(saveFile.timerText, "0:0,5");
            Assert.AreEqual(saveFile.totalTime.ToString("f1"), "0,5");
            Assert.AreEqual(saveFile.totalCollected, 2);

            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
        }
    }
}
