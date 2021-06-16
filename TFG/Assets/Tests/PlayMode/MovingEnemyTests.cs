using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MovingEnemyTests
    {
        [UnityTest]
        public IEnumerator MovingEnemy()
        {
            var enemyObject = new GameObject();
            var enemy = enemyObject.AddComponent<MovingEnemy>();
            enemy.gameObject.AddComponent<SpriteRenderer>();

            GameObject initialObject = new GameObject();
            Transform initialTransform = initialObject.transform;
            enemy.InitialPosition = initialTransform;
            GameObject finalObject = new GameObject();
            Transform finalTransform = finalObject.transform;
            enemy.FinalPosition = finalTransform;

            enemy.InitialPosition.position = new Vector3(-3, 0);
            enemy.FinalPosition.position = new Vector3(3, 0);

            float xOriginalPosition = enemy.transform.position.x;

            // Tests the movement of the enemy
            yield return new WaitForSeconds(1);
            Assert.Less(enemy.transform.position.x, xOriginalPosition);

            yield return new WaitForSeconds(1);
            Assert.AreEqual((int)enemy.transform.position.x, (int)xOriginalPosition);

            yield return new WaitForSeconds(1);
            Assert.Greater(enemy.transform.position.x, xOriginalPosition);

            yield return new WaitForSeconds(1);
            Assert.AreEqual((int)enemy.transform.position.x, (int)xOriginalPosition);

            enemy.InitialPosition.position = enemy.transform.position;
            enemy.FinalPosition.position = new Vector3(0,3);

            yield return new WaitForSeconds(1);
            Assert.Greater(enemy.transform.position.y, enemy.InitialPosition.position.y);

            yield return new WaitForSeconds(1);
            Assert.AreEqual((int)enemy.transform.position.y, (int)enemy.InitialPosition.position.y);
        }
    }
}
