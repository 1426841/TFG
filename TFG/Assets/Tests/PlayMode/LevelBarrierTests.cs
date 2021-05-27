using System.Collections;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class LevelBarrierTests
    {
        [UnityTest]
        public IEnumerator LevelBarrier()
        {
            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);

            var gameObject = new GameObject();
            var levelBarrier = gameObject.AddComponent<LevelBarrier>();

            var saveObject = new GameObject();
            var saveSystem = saveObject.AddComponent<SaveSystem>();
            saveSystem.gameObject.AddComponent<Timer>();
            saveSystem.gameObject.AddComponent<Text>();
            saveSystem.gameObject.AddComponent<Collectables>();
            levelBarrier.saveSystem = saveSystem;
            GameObject barrier = new GameObject();
            levelBarrier.barrier = barrier;
            levelBarrier.levelRequired = 1;

            yield return null;
            Assert.True(levelBarrier.barrier.activeSelf);
            
            //1 level passed
            levelBarrier.saveSystem.Save();

            //Create LevelBarrier gameObject again to call Start a second time
            levelBarrier = gameObject.AddComponent<LevelBarrier>();
            levelBarrier.saveSystem = saveSystem;
            levelBarrier.barrier = barrier;
            levelBarrier.levelRequired = 1;

            yield return null;
            Assert.False(levelBarrier.barrier.activeSelf);
        }
    }
}
