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

        [UnityTest]
        public IEnumerator IsUsingAbility()
        {
            var gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.gameObject.AddComponent<Rigidbody2D>();
            character.gameObject.AddComponent<Animator>();
            character.gameObject.AddComponent<SpriteRenderer>();
            character.gameObject.AddComponent<Ability>();
            character.gameObject.AddComponent<CharacterControl>();

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

            yield return null;

            //Is not using ability
            Assert.False(character.gameObject.GetComponent<Ability>().IsUsingAbility());

            character.gameObject.GetComponent<Ability>().UseAbility(Character.Dash);

            yield return new WaitForSeconds(0.2f);

            //Is using ability
            Assert.True(character.gameObject.GetComponent<Ability>().IsUsingAbility());

            yield return new WaitForSeconds(0.3f);

            //Is not using ability -> Ability is cooldown
            Assert.False(character.gameObject.GetComponent<Ability>().IsUsingAbility());

            yield return new WaitForSeconds(0.5f);

            //Is not using ability
            Assert.False(character.gameObject.GetComponent<Ability>().IsUsingAbility());

            character.gameObject.GetComponent<Ability>().UseAbility(Character.Dash);

            yield return new WaitForSeconds(0.2f);

            //Is using ability
            Assert.True(character.gameObject.GetComponent<Ability>().IsUsingAbility());
        }


        [UnityTest]
        public IEnumerator CanUseAbility()
        {
            var gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.gameObject.AddComponent<Rigidbody2D>();
            character.gameObject.AddComponent<Animator>();
            character.gameObject.AddComponent<SpriteRenderer>();
            character.gameObject.AddComponent<Ability>();
            character.gameObject.AddComponent<CharacterControl>();

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

            yield return null;

            //Can use ability -> Is not using ability
            Assert.True(character.gameObject.GetComponent<Ability>().CanUseAbility());

            character.gameObject.GetComponent<Ability>().UseAbility(Character.Dash);

            yield return new WaitForSeconds(0.2f);

            //Can't use ability -> Is using ability
            Assert.False(character.gameObject.GetComponent<Ability>().CanUseAbility());

            yield return new WaitForSeconds(0.3f);

            //Can't use ability -> Ability is cooldown
            Assert.False(character.gameObject.GetComponent<Ability>().CanUseAbility());

            yield return new WaitForSeconds(0.3f);

            //Can use ability -> Is not using ability
            Assert.True(character.gameObject.GetComponent<Ability>().CanUseAbility());

            character.gameObject.GetComponent<Ability>().UseAbility(Character.Dash);

            yield return new WaitForSeconds(0.8f);

            character.gameObject.GetComponent<Ability>().UseAbility(Character.Dash);

            yield return new WaitForSeconds(0.5f);

            //Can't use ability -> No ability points and ability is cooldown
            Assert.False(character.gameObject.GetComponent<Ability>().CanUseAbility());

            yield return new WaitForSeconds(0.3f);

            //Can't use ability -> No ability points and ability is not cooldown
            Assert.False(character.gameObject.GetComponent<Ability>().CanUseAbility());

            character.gameObject.GetComponent<Ability>().ResetAbility();

            //Can use ability -> 3 ability points
            Assert.True(character.gameObject.GetComponent<Ability>().CanUseAbility());
        }
    }
}
