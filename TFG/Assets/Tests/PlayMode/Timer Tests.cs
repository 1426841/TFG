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

            Assert.AreEqual(timer.GetTotalTime(), 0);

            yield return new WaitForSeconds(1);
            Assert.AreEqual((int) timer.GetTotalTime(), 1);

            yield return new WaitForSeconds(0.5f);
            Assert.AreEqual(timer.GetTotalTime().ToString("f1"), "1,5");
        }

        [UnityTest]
        public IEnumerator TimerText()
        {
            var gameObject = new GameObject();
            var timer = gameObject.AddComponent<Timer>();
            timer.gameObject.AddComponent<Text>();

            yield return null;

            //Time may vary slightly between tests, the two consecutive decimals are valid
            if (timer.GetTimerText() == "0:0,01")
            {
                Assert.AreEqual(timer.GetTimerText(), "0:0,01");
            }
            else
            {
                Assert.AreEqual(timer.GetTimerText(), "0:0,02");
            }
            
            yield return new WaitForSeconds(1);
            if (timer.GetTimerText() == "0:1,01")
            {
                Assert.AreEqual(timer.GetTimerText(), "0:1,01");
            } else
            {
                Assert.AreEqual(timer.GetTimerText(), "0:1,02");
            }

            yield return new WaitForSeconds(59.5f);
            if (timer.GetTimerText() == "1:0,51")
            {
                Assert.AreEqual(timer.GetTimerText(), "1:0,51");
            }
            else
            {
                Assert.AreEqual(timer.GetTimerText(), "1:0,52");
            }

        }
    }
}
