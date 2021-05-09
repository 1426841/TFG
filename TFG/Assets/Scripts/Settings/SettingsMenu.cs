using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu;

    void Start()
    {
        settingsMenu.gameObject.SetActive(true);
    }

    public void OpenCloseSettings()
    {
        if (settingsMenu.activeSelf)
        {
            settingsMenu.gameObject.SetActive(false);
        }
        else
        {
            settingsMenu.gameObject.SetActive(true);
        }
    }
}
