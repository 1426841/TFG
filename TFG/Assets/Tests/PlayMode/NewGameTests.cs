using System.Collections;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class NewGameTests
    {
        [UnityTest]
        public IEnumerator CreateNewGame()
        {
            var gameObject = new GameObject();
            var newGame = gameObject.AddComponent<NewGame>();

            var saveObject = new GameObject();
            var saveSystem = saveObject.AddComponent<SaveSystem>();
            saveSystem.gameObject.AddComponent<Timer>();
            saveSystem.gameObject.AddComponent<Text>();
            saveSystem.gameObject.AddComponent<Collectables>();

            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
            Assert.IsFalse(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));

            yield return null;
            saveSystem.Save();

            Assert.IsTrue(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));
            Assert.AreNotEqual(SceneManager.GetActiveScene().name, "Main");

            //Deletes old save
            newGame.CreateNewGame();
            yield return null;

            Assert.IsFalse(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));
            Assert.AreEqual(SceneManager.GetActiveScene().name, "Main");

            //Creates new game but there is no old save
            newGame.CreateNewGame();
            yield return null;

            Assert.IsFalse(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));
            Assert.AreEqual(SceneManager.GetActiveScene().name, "Main");
        }
    }
}
