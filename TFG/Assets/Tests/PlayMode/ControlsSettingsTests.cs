using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class ControlsSettingsTests
    {
        [UnityTest]
        public IEnumerator SetMovementControls()
        {
            var gameObject = new GameObject();
            var controlsSettings = gameObject.AddComponent<ControlsSettings>();
            controlsSettings.gameObject.AddComponent<Controller>();

            Text text = controlsSettings.gameObject.AddComponent<Text>();
            controlsSettings.dashKey = text;
            controlsSettings.repeatedKey = text;

            Dropdown dropdown = controlsSettings.gameObject.AddComponent<Dropdown>();
            controlsSettings.movementsDropdown = dropdown;

            yield return null;

            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetRight(), "right");
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetLeft(), "left");
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetJump(), "up");

            controlsSettings.SetMovementControls(1);

            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetRight(), "d");
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetLeft(), "a");
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetJump(), "w");
            Assert.False(controlsSettings.repeatedKey.IsActive());

            controlsSettings.SetMovementControls(0);

            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetRight(), "right");
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetLeft(), "left");
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetJump(), "up");
            Assert.False(controlsSettings.repeatedKey.IsActive());

            controlsSettings.gameObject.GetComponent<Controller>().SetDash("a");

            controlsSettings.SetMovementControls(1);

            //Can't change movement controls because dash is using "a" key
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetRight(), "right");
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetLeft(), "left");
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetJump(), "up");
            Assert.True(controlsSettings.repeatedKey.IsActive());

            controlsSettings.gameObject.GetComponent<Controller>().SetDash("q");

            controlsSettings.SetMovementControls(1);

            //Can change movement controls because dash is not using "a" key
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetRight(), "d");
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetLeft(), "a");
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetJump(), "w");
            Assert.False(controlsSettings.repeatedKey.IsActive());

        }
    }
}
