using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GraphicsSettings : MonoBehaviour
{
    public Toggle toggle;
    public EventSystem eventSystem;
    public Dropdown resolutionsDropdown;
    private Resolution[] screenResolutions;

    private void Start()
    {
        resolutionsDropdown.ClearOptions();
        screenResolutions = Screen.resolutions;
        List<string> optionsDropdown = new List<string>();
        int currentResolution = 0;

        for (int i = 0; i < screenResolutions.Length; i++)
        {
            // Only adds resolutions that have 59 or 60 Hz
            if((screenResolutions[i].refreshRate == 59) || (screenResolutions[i].refreshRate == 60))
            {
                optionsDropdown.Add(screenResolutions[i].ToString());
            }
            
            // Searches the current resolution in screenResolutions
            if(screenResolutions[i].width == Screen.width && screenResolutions[i].height == Screen.height && 
                (screenResolutions[i].refreshRate == Screen.currentResolution.refreshRate || screenResolutions[i].refreshRate+1 == Screen.currentResolution.refreshRate))
            {
                currentResolution = i;
            }
        }

        resolutionsDropdown.AddOptions(optionsDropdown);
        resolutionsDropdown.value = currentResolution;
        resolutionsDropdown.RefreshShownValue();
    }

    public void Fullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SelectFirstSetting()
    {
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(toggle.gameObject);
    }

    public void SetResolution(int selectedResolution)
    {
        Resolution resolution = screenResolutions[selectedResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
