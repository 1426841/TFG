using System.Collections;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Tests
{
    public class NewGameTests
    {
        [UnityTest]
        public IEnumerator CreateNewGame()
        {
            SceneManager.LoadScene("Initial");
            yield return null;

            var gameObject = new GameObject();
            var newGame = gameObject.AddComponent<NewGame>();

            GameObject videoPlayer = GameObject.Find("Video Player");
            newGame.videoPlayer = videoPlayer.GetComponent<VideoPlayer>();

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
            Assert.IsFalse(newGame.videoPlayer.isPlaying);

            yield return null;
            Assert.IsFalse(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));

            yield return new WaitForSeconds(5);
            Assert.IsTrue(newGame.videoPlayer.isPlaying);

            yield return new WaitForSeconds(5);
            Assert.AreEqual(SceneManager.GetActiveScene().name, "Main");

            SceneManager.LoadScene("Initial");
            yield return null;

            videoPlayer = GameObject.Find("Video Player");
            newGame.videoPlayer = videoPlayer.GetComponent<VideoPlayer>();

            //Creates new game but there is no old save
            newGame.CreateNewGame();
            yield return new WaitForSeconds(10);

            Assert.IsFalse(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));
            Assert.AreEqual(SceneManager.GetActiveScene().name, "Main");
        }
    }
}
