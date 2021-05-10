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

            var cameraObject = new GameObject();
            var camera = cameraObject.AddComponent<Camera>();

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

            var cameraObject = new GameObject();
            var camera = cameraObject.AddComponent<Camera>();

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

            var cameraObject = new GameObject();
            var camera = cameraObject.AddComponent<Camera>();

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

            var cameraObject = new GameObject();
            var camera = cameraObject.AddComponent<Camera>();

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

            var cameraObject = new GameObject();
            var camera = cameraObject.AddComponent<Camera>();

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

            var cameraObject = new GameObject();
            var camera = cameraObject.AddComponent<Camera>();

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

            float originalPosition = character.transform.position.y;

            yield return null;

            character.SetAction(Character.Respawn);

            yield return new WaitForSeconds(1);
            
            Assert.Less(character.transform.position.y, originalPosition);
            Assert.Greater(character.transform.position.y, CharacterControl.RespawnPosition);
        }

        [UnityTest]
        public IEnumerator Damage()
        {
            var gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.gameObject.AddComponent<Rigidbody2D>();
            character.gameObject.AddComponent<Animator>();

            var cameraObject = new GameObject();
            var camera = cameraObject.AddComponent<Camera>();

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

            yield return null;

            //3 hearts, 0 noHearts
            Assert.True(character.heart1.activeSelf);
            Assert.True(character.heart2.activeSelf);
            Assert.True(character.heart3.activeSelf);
            Assert.False(character.noHeart1.activeSelf);
            Assert.False(character.noHeart2.activeSelf);
            Assert.False(character.noHeart3.activeSelf);

            character.Damage();
            yield return null;

            //2 hearts, 1 noHeart
            Assert.False(character.heart1.activeSelf);
            Assert.True(character.heart2.activeSelf);
            Assert.True(character.heart3.activeSelf);
            Assert.True(character.noHeart1.activeSelf);
            Assert.False(character.noHeart2.activeSelf);
            Assert.False(character.noHeart3.activeSelf);

            character.Damage();
            yield return null;

            //1 heart, 2 noHearts
            Assert.False(character.heart1.activeSelf);
            Assert.False(character.heart2.activeSelf);
            Assert.True(character.heart3.activeSelf);
            Assert.True(character.noHeart1.activeSelf);
            Assert.True(character.noHeart2.activeSelf);
            Assert.False(character.noHeart3.activeSelf);

            character.Damage();
            yield return new WaitForSeconds(0.1f);

            //3 hearts, 0 noHearts
            Assert.True(character.heart1.activeSelf);
            Assert.True(character.heart2.activeSelf);
            Assert.True(character.heart3.activeSelf);
            Assert.False(character.noHeart1.activeSelf);
            Assert.False(character.noHeart2.activeSelf);
            Assert.False(character.noHeart3.activeSelf);

            character.Damage();
            yield return null;

            //2 hearts, 1 noHeart
            Assert.False(character.heart1.activeSelf);
            Assert.True(character.heart2.activeSelf);
            Assert.True(character.heart3.activeSelf);
            Assert.True(character.noHeart1.activeSelf);
            Assert.False(character.noHeart2.activeSelf);
            Assert.False(character.noHeart3.activeSelf);

            character.SetAction(Character.Respawn);
            yield return new WaitForSeconds(0.1f);

            //3 hearts, 0 noHearts
            Assert.True(character.heart1.activeSelf);
            Assert.True(character.heart2.activeSelf);
            Assert.True(character.heart3.activeSelf);
            Assert.False(character.noHeart1.activeSelf);
            Assert.False(character.noHeart2.activeSelf);
            Assert.False(character.noHeart3.activeSelf);
        }

        [UnityTest]
        public IEnumerator setRespawnPosition()
        {
            var gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.gameObject.AddComponent<Rigidbody2D>();
            character.gameObject.AddComponent<Animator>();

            var cameraObject = new GameObject();
            var camera = cameraObject.AddComponent<Camera>();

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

            yield return null;

            character.SetAction(Character.Respawn);

            yield return new WaitForSeconds(0.1f);

            Assert.AreEqual(character.transform.position.x, -7);
            Assert.AreEqual((int) character.transform.position.y, -3);
            Assert.AreEqual(character.transform.position.z, 0);

            character.setRespawnPosition(new Vector3(10, -5, -2));

            character.SetAction(Character.Respawn);

            yield return new WaitForSeconds(0.1f);

            Assert.AreEqual(character.transform.position.x, 10);
            Assert.AreEqual((int) character.transform.position.y, -5);
            Assert.AreEqual(character.transform.position.z, -2);
        }
    }
}
