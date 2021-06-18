using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class NewGame : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject rawImage;
    public GameObject continueGameButton;
    public GameObject exitGameButton;
    public GameObject newGamebutton;
    public GameObject textControls;

    public void CreateNewGame()
    {
        File.Delete(Application.dataPath + SaveSystem.SaveFilePath);

        // Disables buttons and text before playing video
        continueGameButton.SetActive(false);
        exitGameButton.SetActive(false);
        newGamebutton.SetActive(false);
        textControls.SetActive(false);

        rawImage.SetActive(true);
        videoPlayer.Play();
        
        // When the video ends, it loads the scene
        videoPlayer.loopPointReached += LoadMain;
    }

    private void LoadMain(VideoPlayer videoPlayer)
    {
        SceneManager.LoadScene("Main");
    }
}
