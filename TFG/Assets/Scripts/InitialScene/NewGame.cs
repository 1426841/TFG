using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class NewGame : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void CreateNewGame()
    {
        File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
        videoPlayer.Play();

        // When the video ends, it loads the scene
        videoPlayer.loopPointReached += LoadMain;
    }

    private void LoadMain(VideoPlayer videoPlayer)
    {
        SceneManager.LoadScene("Main");
    }
}
