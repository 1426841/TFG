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

            var buttonObject = new GameObject();
            continueGame.continueButton = buttonObject;

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

            // Continue -> loads Main scene
            Assert.AreEqual(SceneManager.GetActiveScene().name, "Main");

            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
        }

        [UnityTest]
        public IEnumerator Start()
        {
            var gameObject = new GameObject();
            var continueGame = gameObject.AddComponent<ContinueGame>();

            var buttonObject = new GameObject();
            continueGame.continueButton = buttonObject;

            var saveObject = new GameObject();
            var saveSystem = saveObject.AddComponent<SaveSystem>();
            saveSystem.gameObject.AddComponent<Timer>();
            saveSystem.gameObject.AddComponent<Text>();
            saveSystem.gameObject.AddComponent<Collectables>();

            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
            Assert.IsFalse(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));

            yield return null;
            // There is no save -> Can't continue
            Assert.IsFalse(continueGame.continueButton.activeSelf);
            saveSystem.Save();

            //Create ContinueGame gameObject again to call Start
            continueGame = gameObject.AddComponent<ContinueGame>();
            var buttonObject2 = new GameObject();
            continueGame.continueButton = buttonObject2;

            yield return null;
            Assert.IsTrue(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));
            // There is save -> Can continue
            Assert.IsTrue(continueGame.continueButton.activeSelf);

            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
        }
    }
}
