using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Tests
{
    public class SettingsMenuTests
    {
        [Test]
        public void OpenCloseSettings()
        {
            var gameObject = new GameObject();
            var settingsMenu = gameObject.AddComponent<SettingsMenu>();

            GameObject settingsMenuGameObject = new GameObject();
            settingsMenu.settingsMenu = settingsMenuGameObject;

            GraphicsSettings graphicsSettings = gameObject.AddComponent<GraphicsSettings>();
            Toggle toggle = gameObject.AddComponent<Toggle>();
            graphicsSettings.toggle = toggle;
            EventSystem eventSystem = gameObject.AddComponent<EventSystem>();
            graphicsSettings.eventSystem = eventSystem;
            settingsMenu.graphicsSettings = graphicsSettings;

            // Checks if settingsMenu is opened or closed
            Assert.True(settingsMenu.settingsMenu.activeSelf);

            settingsMenu.OpenCloseSettings();
            Assert.False(settingsMenu.settingsMenu.activeSelf);

            settingsMenu.OpenCloseSettings();
            Assert.True(settingsMenu.settingsMenu.activeSelf);
        }
    }
}
