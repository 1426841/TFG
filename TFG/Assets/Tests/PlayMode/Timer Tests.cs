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
        public IEnumerator TotalTime()
        {
            var gameObject = new GameObject();
            var timer = gameObject.AddComponent<Timer>();
            timer.gameObject.AddComponent<Text>();

            Time.timeScale = 1;

            Assert.AreEqual(timer.GetTotalTime(), 0);

            yield return new WaitForSeconds(1);
            Assert.AreEqual((int) timer.GetTotalTime(), 1);

            yield return new WaitForSeconds(0.5f);
            Assert.AreEqual(timer.GetTotalTime().ToString("f1"), "1,5");

            Time.timeScale = 100;

            yield return new WaitForSeconds(298);

            Time.timeScale = 1;

            yield return new WaitForSeconds(0.5f);
            Assert.AreEqual((int) timer.GetTotalTime(), 300);

            // TotalTime doesn't increase because MaxTime is 300
            yield return new WaitForSeconds(1);
            Assert.AreEqual((int) timer.GetTotalTime(), 300);
        }

        [UnityTest]
        public IEnumerator TimerText()
        {
            var gameObject = new GameObject();
            var timer = gameObject.AddComponent<Timer>();
            timer.gameObject.AddComponent<Text>();

            yield return null;
            Assert.AreEqual(timer.GetTimerText(), "0:0,0");

            yield return new WaitForSeconds(1);
            Assert.AreEqual(timer.GetTimerText(), "0:1,0");

            yield return new WaitForSeconds(59.5f);
            Assert.AreEqual(timer.GetTimerText(), "1:0,5");

            Time.timeScale = 100;

            yield return new WaitForSeconds(238);
            
            Time.timeScale = 1;
            yield return new WaitForSeconds(1.5f);
            Assert.AreEqual(timer.GetTimerText(), "5:0,0");

            // TimerText doesn't increase because MaxTime is 300
            yield return new WaitForSeconds(1);
            Assert.AreEqual(timer.GetTimerText(), "5:0,0");
        }

        [UnityTest]
        public IEnumerator IsFinish()
        {
            var gameObject = new GameObject();
            var timer = gameObject.AddComponent<Timer>();
            timer.gameObject.AddComponent<Text>();

            yield return null;
            string initialTime = timer.GetTimerText();
            timer.SetIsFinish(true);

            yield return new WaitForSeconds(1);
            Assert.AreEqual(timer.GetTimerText(), initialTime);
        }

        [UnityTest]
        public IEnumerator ResetTime()
        {
            var gameObject = new GameObject();
            var timer = gameObject.AddComponent<Timer>();
            timer.gameObject.AddComponent<Text>();

            yield return new WaitForSeconds(0.5f);
            timer.ResetTime();

            yield return new WaitForSeconds(1);
            Assert.AreEqual(timer.GetTimerText(), "0:1,0");
        }
    }
}
