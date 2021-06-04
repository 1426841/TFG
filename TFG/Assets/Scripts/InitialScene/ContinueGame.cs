using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour
{
    public GameObject continueButton;
    private void Start()
    {
        if(!File.Exists(Application.dataPath + SaveSystem.SaveFilePath))
        {
            continueButton.SetActive(false);
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene("Main");
    }
}
