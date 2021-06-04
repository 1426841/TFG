using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("Main");
    }
}
