using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CharacterTests
    {
        [UnityTest]
        public IEnumerator MoveRight()
        {
            var gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.gameObject.AddComponent<Rigidbody2D>();
            float originalPosition = character.transform.position.x;

            yield return null;

            character.SetAction("moveRight");
            
            yield return new WaitForSeconds(1);

            Assert.Greater(character.transform.position.x, originalPosition);
        }
    }
}
