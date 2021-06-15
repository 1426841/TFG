using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HorizontalMovingEnemyTests
    {
        [UnityTest]
        public IEnumerator HorizontalMovingEnemy()
        {
            var enemyObject = new GameObject();
            var enemy = enemyObject.AddComponent<HorizontalMovingEnemy>();
            enemy.gameObject.AddComponent<SpriteRenderer>();

            GameObject initialObject = new GameObject();
            Transform initialTransform = initialObject.transform;
            enemy.InitialPosition = initialTransform;
            GameObject finalObject = new GameObject();
            Transform finalTransform = finalObject.transform;
            enemy.FinalPosition = finalTransform;

            enemy.InitialPosition.position = new Vector3(-3, 0);
            enemy.FinalPosition.position = new Vector3(3, 0);

            float originalPosition = enemy.transform.position.x;

            // Tests the movement of the enemy
            yield return new WaitForSeconds(1);
            Assert.Less(enemy.transform.position.x, originalPosition);

            yield return new WaitForSeconds(1);
            Assert.AreEqual((int)enemy.transform.position.x, (int)originalPosition);

            yield return new WaitForSeconds(1);
            Assert.Greater(enemy.transform.position.x, originalPosition);

            yield return new WaitForSeconds(1);
            Assert.AreEqual((int)enemy.transform.position.x, (int)originalPosition);
        }
    }
}
