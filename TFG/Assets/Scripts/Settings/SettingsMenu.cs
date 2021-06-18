using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    private const string MainScene = "Main";
    private const string InitialScene = "Initial";

    public GameObject settingsMenu;
    public GraphicsSettings graphicsSettings;

    void Start()
    {
        settingsMenu.gameObject.SetActive(true);
    }

    public void OpenCloseSettings()
    {
        if (settingsMenu.activeSelf)
        {
            // If the settings menu is already opened, closes the menu and resumes the game
            Time.timeScale = 1;
            settingsMenu.gameObject.SetActive(false);
        }
        else
        {
            // If the settings menu is closed, opens the settings menu and pauses the game
            Time.timeScale = 0;
            settingsMenu.gameObject.SetActive(true);
            graphicsSettings.SelectFirstSetting();
        }
    }

    public bool isOpenSettings()
    {
        return settingsMenu.activeSelf;
    } 

    public void ExitLevel()
    {
        if (SceneManager.GetActiveScene().name == MainScene)
        {
            SceneManager.LoadScene(InitialScene);
        }
        else
        {
            SceneManager.LoadScene(MainScene);
        }
    }
}
