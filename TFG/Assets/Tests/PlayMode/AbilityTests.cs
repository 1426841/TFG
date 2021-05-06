using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class AbilityTests
    {
        [UnityTest]
        public IEnumerator Dash()
        {
            var gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.gameObject.AddComponent<Rigidbody2D>();
            character.gameObject.AddComponent<Animator>();
            character.gameObject.AddComponent<SpriteRenderer>();

            GameObject heart1 = new GameObject();
            GameObject heart2 = new GameObject();
            GameObject heart3 = new GameObject();
            GameObject noHeart1 = new GameObject();
            GameObject noHeart2 = new GameObject();
            GameObject noHeart3 = new GameObject();

            character.heart1 = heart1;
            character.heart2 = heart2;
            character.heart3 = heart3;
            character.noHeart1 = noHeart1;
            character.noHeart2 = noHeart2;
            character.noHeart3 = noHeart3;

            var cameraObject = new GameObject();
            var camera = cameraObject.AddComponent<Camera>();

            float originalPosition = character.transform.position.x;
            yield return null;

            character.SetAction(Character.Dash);

            yield return new WaitForSeconds(0.1f);

            Assert.Greater(character.transform.position.x, originalPosition);
        }
    }
}
