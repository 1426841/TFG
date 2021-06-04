using System.Collections;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class ContinueGameTests
    {

        [UnityTest]
        public IEnumerator Continue()
        {
            SceneManager.LoadScene("Initial");
            yield return null;

            var gameObject = new GameObject();
            var continueGame = gameObject.AddComponent<ContinueGame>();

            var saveObject = new GameObject();
            var saveSystem = saveObject.AddComponent<SaveSystem>();
            saveSystem.gameObject.AddComponent<Timer>();
            saveSystem.gameObject.AddComponent<Text>();
            saveSystem.gameObject.AddComponent<Collectables>();

            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
            Assert.IsFalse(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));

            yield return null;
            saveSystem.Save();


            Assert.AreNotEqual(SceneManager.GetActiveScene().name, "Main");


            continueGame.Continue();
            yield return null;

            Assert.AreEqual(SceneManager.GetActiveScene().name, "Main");
        }
    }
}
