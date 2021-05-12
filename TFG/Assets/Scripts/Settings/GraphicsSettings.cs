using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GraphicsSettings : MonoBehaviour
{
    public Toggle toggle;
    public EventSystem eventSystem;
    public void Fullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SelectFirstSetting()
    {
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(toggle.gameObject);
    }
}
