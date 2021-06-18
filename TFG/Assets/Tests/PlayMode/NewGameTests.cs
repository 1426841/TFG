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

            var newGameButton = new GameObject();
            var continueGameButton = new GameObject();
            var exitGameButton = new GameObject();
            var rawImage = new GameObject();
            var textControls = new GameObject();
            newGame.newGamebutton = newGameButton;
            newGame.continueGameButton = continueGameButton;
            newGame.exitGameButton = exitGameButton;
            newGame.rawImage = rawImage;
            newGame.rawImage.SetActive(false);
            newGame.textControls = textControls;

            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
            Assert.IsFalse(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));

            yield return null;
            saveSystem.Save();

            Assert.IsTrue(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));
            Assert.AreNotEqual(SceneManager.GetActiveScene().name, "Main");

            Assert.IsTrue(newGame.newGamebutton.activeSelf);
            Assert.IsTrue(newGame.continueGameButton.activeSelf);
            Assert.IsTrue(newGame.exitGameButton.activeSelf);
            Assert.IsFalse(newGame.rawImage.activeSelf);
            Assert.IsTrue(newGame.textControls.activeSelf);

            //Deletes old save
            newGame.CreateNewGame();
            Assert.IsFalse(newGame.videoPlayer.isPlaying);

            yield return null;
            Assert.IsFalse(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));

            yield return new WaitForSeconds(5);

            //Disables buttons and plays video
            Assert.IsFalse(newGame.newGamebutton.activeSelf);
            Assert.IsFalse(newGame.continueGameButton.activeSelf);
            Assert.IsFalse(newGame.exitGameButton.activeSelf);
            Assert.IsTrue(newGame.rawImage.activeSelf);
            Assert.IsFalse(newGame.textControls.activeSelf);

            Assert.IsTrue(newGame.videoPlayer.isPlaying);

            yield return new WaitForSeconds(5);
            Assert.AreEqual(SceneManager.GetActiveScene().name, "Main");

            SceneManager.LoadScene("Initial");
            yield return null;

            var newGameButton2 = new GameObject();
            var continueGameButton2 = new GameObject();
            var exitGameButton2 = new GameObject();
            var rawImage2 = new GameObject();
            var textControls2 = new GameObject();
            newGame.newGamebutton = newGameButton2;
            newGame.continueGameButton = continueGameButton2;
            newGame.exitGameButton = exitGameButton2;
            newGame.rawImage = rawImage2;
            newGame.rawImage.SetActive(false);
            newGame.textControls = textControls2;

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
