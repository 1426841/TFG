using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class test
    {
        [Test]
        public void OpenCloseSettings()
        {
            var gameObject = new GameObject();
            var settingsMenu = gameObject.AddComponent<SettingsMenu>();

            GameObject settingsMenuGameObject = new GameObject();
            settingsMenu.settingsMenu = settingsMenuGameObject;

            Assert.True(settingsMenu.settingsMenu.activeSelf);

            settingsMenu.OpenCloseSettings();
            Assert.False(settingsMenu.settingsMenu.activeSelf);

            settingsMenu.OpenCloseSettings();
            Assert.True(settingsMenu.settingsMenu.activeSelf);
        }
    }
}
