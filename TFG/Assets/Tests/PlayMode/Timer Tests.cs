using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class TimerTests
    {
        
        [UnityTest]
        public IEnumerator CountTotalTime()
        {
            var gameObject = new GameObject();
            var timer = gameObject.AddComponent<Timer>();
            timer.gameObject.AddComponent<Text>();

            Assert.AreEqual(timer.GetTotalTime(), 0);

            yield return new WaitForSeconds(1);
            Assert.AreEqual((int) timer.GetTotalTime(), 1);

            yield return new WaitForSeconds(0.5f);
            Assert.AreEqual(timer.GetTotalTime().ToString("f1"), "1,5");
        }
    }
}
