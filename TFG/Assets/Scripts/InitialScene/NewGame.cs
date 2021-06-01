using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void CreateNewGame()
    {
        File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
        SceneManager.LoadScene("Main");
    }
}
