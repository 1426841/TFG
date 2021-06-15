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

            Text text = controlsSettings.gameObject.AddComponent<Text>();
            controlsSettings.dashKey = text;
            controlsSettings.healKey = text;
            controlsSettings.repeatedKey = text;

            Dropdown dropdown = controlsSettings.gameObject.AddComponent<Dropdown>();
            controlsSettings.movementsDropdown = dropdown;

            var controllerObject = new GameObject();
            var controller = gameObject.AddComponent<Controller>();
            controlsSettings.controller = controller;

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

        [UnityTest]
        public IEnumerator SetDashControl()
        {
            var gameObject = new GameObject();
            var controlsSettings = gameObject.AddComponent<ControlsSettings>();

            Text text = controlsSettings.gameObject.AddComponent<Text>();
            controlsSettings.dashKey = text;
            controlsSettings.healKey = text;
            controlsSettings.repeatedKey = text;

            Dropdown dropdown = controlsSettings.gameObject.AddComponent<Dropdown>();
            controlsSettings.movementsDropdown = dropdown;

            var controllerObject = new GameObject();
            var controller = gameObject.AddComponent<Controller>();
            controlsSettings.controller = controller;

            yield return null;

            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetDash(), "q");
            
            controlsSettings.SetDashControl("z");

            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetDash(), "z");

            controlsSettings.SetDashControl("");

            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetDash(), "z");

            controlsSettings.SetMovementControls(1);

            controlsSettings.SetDashControl("a");

            //Can't change dash control because movementControls is using "a" key
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetDash(), "z");

            // Converts the key to lowercase
            controlsSettings.SetDashControl("B");
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetDash(), "b");

            controlsSettings.SetDashControl("e");

            //Can't change dash control because heal is using "e" key
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetDash(), "b");
        }

        public IEnumerator SetHealControl()
        {
            var gameObject = new GameObject();
            var controlsSettings = gameObject.AddComponent<ControlsSettings>();

            Text text = controlsSettings.gameObject.AddComponent<Text>();
            controlsSettings.dashKey = text;
            controlsSettings.healKey = text;
            controlsSettings.repeatedKey = text;

            Dropdown dropdown = controlsSettings.gameObject.AddComponent<Dropdown>();
            controlsSettings.movementsDropdown = dropdown;

            var controllerObject = new GameObject();
            var controller = gameObject.AddComponent<Controller>();
            controlsSettings.controller = controller;

            yield return null;

            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetHeal(), "e");

            controlsSettings.SetHealControl("z");

            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetHeal(), "z");

            controlsSettings.SetHealControl("");

            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetHeal(), "z");

            controlsSettings.SetMovementControls(1);

            controlsSettings.SetHealControl("a");

            //Can't change heal control because movementControls is using "a" key
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetHeal(), "z");

            // Converts the key to lowercase
            controlsSettings.SetHealControl("B");
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetHeal(), "b");

            controlsSettings.SetHealControl("q");

            //Can't change heal control because dash is using "q" key
            Assert.AreEqual(controlsSettings.gameObject.GetComponent<Controller>().GetHeal(), "b");
        }
    }
}
