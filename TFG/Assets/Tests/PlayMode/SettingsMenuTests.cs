using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class SettingsMenuTests
    {
        [UnityTest]
        public IEnumerator ExitLevel()
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
            var dropdownObject = new GameObject();
            Dropdown dropdown = dropdownObject.gameObject.AddComponent<Dropdown>();
            graphicsSettings.resolutionsDropdown = dropdown;

            settingsMenu.ExitLevel();

            yield return null;

            //Exits level and loads Main scene
            Assert.AreEqual(SceneManager.GetActiveScene().name, "Main");
        }
    }
}
