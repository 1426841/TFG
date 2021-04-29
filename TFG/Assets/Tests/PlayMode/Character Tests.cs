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
            character.gameObject.AddComponent<Animator>();
            character.gameObject.AddComponent<SpriteRenderer>();

            float originalPosition = character.transform.position.x;

            yield return null;

            character.SetAction(Character.MoveRight);
            
            yield return new WaitForSeconds(1);

            Assert.Greater(character.transform.position.x, originalPosition);
        }

        [UnityTest]
        public IEnumerator MoveLeft()
        {
            var gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.gameObject.AddComponent<Rigidbody2D>();
            character.gameObject.AddComponent<Animator>();
            character.gameObject.AddComponent<SpriteRenderer>();

            float originalPosition = character.transform.position.x;

            yield return null;

            character.SetAction(Character.MoveLeft);

            yield return new WaitForSeconds(1);

            Assert.Less(character.transform.position.x, originalPosition);
        }

        [UnityTest]
        public IEnumerator NoMove()
        {
            var gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.gameObject.AddComponent<Rigidbody2D>();
            character.gameObject.AddComponent<Animator>();

            float originalPosition = character.transform.position.x;

            yield return null;

            character.SetAction(Character.NoMove);

            yield return new WaitForSeconds(1);

            Assert.AreEqual(character.transform.position.x, originalPosition);
        }

        [UnityTest]
        public IEnumerator WrongAction()
        {
            var gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.gameObject.AddComponent<Rigidbody2D>();
            character.gameObject.AddComponent<Animator>();

            float originalPosition = character.transform.position.x;

            yield return null;

            character.SetAction("wrongAction");

            yield return new WaitForSeconds(1);

            LogAssert.Expect(LogType.Warning, "Wrong character action!");
        }

        [UnityTest]
        public IEnumerator Jump()
        {
            var gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.gameObject.AddComponent<Rigidbody2D>();
            character.gameObject.AddComponent<Animator>();

            float originalPosition = character.transform.position.y;

            yield return null;

            character.SetAction(Character.Jump);

            yield return new WaitForSeconds(1);

            Assert.Greater(character.transform.position.y, originalPosition);
        }

        [UnityTest]
        public IEnumerator Respawn()
        {
            var gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.gameObject.AddComponent<Rigidbody2D>();
            character.gameObject.AddComponent<Animator>();

            float originalPosition = character.transform.position.y;

            yield return null;

            character.SetAction(Character.Respawn);

            yield return new WaitForSeconds(1);
            
            Assert.Less(character.transform.position.y, originalPosition);
            Assert.Greater(character.transform.position.y, CharacterControl.RespawnPosition);
        }
    }
}
