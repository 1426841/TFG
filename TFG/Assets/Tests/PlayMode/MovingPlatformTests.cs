using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MovingPlatformTests
    {   
        [UnityTest]
        public IEnumerator MovingPlatform()
        {
            var platformObject = new GameObject();
            var platform = platformObject.AddComponent<MovingPlatform>();

            GameObject initialObject = new GameObject();
            Transform initialTransform = initialObject.transform;
            platform.InitialPosition = initialTransform;
            GameObject finalObject = new GameObject();
            Transform finalTransform = finalObject.transform;
            platform.FinalPosition =  finalTransform;
            
            platform.InitialPosition.position = new Vector3(-3, 0);
            platform.FinalPosition.position = new Vector3(3, 0);

            float originalPosition = platform.transform.position.x;

            // Tests the movement of the platform
            yield return new WaitForSeconds(1);
            Assert.Less(platform.transform.position.x, originalPosition);

            yield return new WaitForSeconds(1);
            Assert.AreEqual((int)platform.transform.position.x, (int)originalPosition);

            yield return new WaitForSeconds(1);
            Assert.Greater(platform.transform.position.x, originalPosition);

            yield return new WaitForSeconds(1);
            Assert.AreEqual((int)platform.transform.position.x,(int) originalPosition);

            platform.InitialPosition.position = platform.transform.position;
            platform.FinalPosition.position = new Vector3(0, 3);

            yield return new WaitForSeconds(1);
            Assert.Greater(platform.transform.position.y, platform.InitialPosition.position.y);

            yield return new WaitForSeconds(1);
            Assert.AreEqual((int)platform.transform.position.y, (int)platform.InitialPosition.position.y);
        }
    }
}
