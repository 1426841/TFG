using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class CollectableTests
    {
        [UnityTest]
        public IEnumerator Collect()
        {
            var gameObject = new GameObject();
            var collectables = gameObject.AddComponent<Collectables>();
            collectables.gameObject.AddComponent<Text>();

            yield return null;
            Assert.AreEqual(collectables.GetCollectablesText(), "0");

            collectables.Collect();

            Assert.AreEqual(collectables.GetCollectablesText(), "1");

            collectables.Collect();

            Assert.AreEqual(collectables.GetCollectablesText(), "2");
        }
    }
}
