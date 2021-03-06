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

            GameObject audioGameObject = new GameObject();
            var audio = audioGameObject.AddComponent<AudioSource>();
            character.jumpAudio = audio;
            character.dashAudio = audio;

            float originalPosition = character.transform.position.x;
            yield return null;

            character.SetAction(Character.Dash);

            yield return new WaitForSeconds(0.1f);

            // Character has moved because of Dash
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
            character.gameObject.AddComponent<SettingsMenu>();
            character.gameObject.AddComponent<Controller>();

            GameObject settingsMenuGameObject = new GameObject();
            character.GetComponent<SettingsMenu>().settingsMenu = settingsMenuGameObject;

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

            GameObject audioGameObject = new GameObject();
            var audio = audioGameObject.AddComponent<AudioSource>();
            character.jumpAudio = audio;
            character.dashAudio = audio;

            GameObject abilityPoint1 = new GameObject();
            GameObject abilityPoint2 = new GameObject();
            GameObject habilityPoint3 = new GameObject();
            GameObject noAbilityPoint1 = new GameObject();
            GameObject noAbilityPoint2 = new GameObject();
            GameObject noAbilityPoint3 = new GameObject();

            character.gameObject.GetComponent<Ability>().abilityPoint1 = abilityPoint1;
            character.gameObject.GetComponent<Ability>().abilityPoint2 = abilityPoint2;
            character.gameObject.GetComponent<Ability>().abilityPoint3 = habilityPoint3;
            character.gameObject.GetComponent<Ability>().noAbilityPoint1 = noAbilityPoint1;
            character.gameObject.GetComponent<Ability>().noAbilityPoint2 = noAbilityPoint2;
            character.gameObject.GetComponent<Ability>().noAbilityPoint3 = noAbilityPoint3;

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
            character.gameObject.AddComponent<SettingsMenu>();
            character.gameObject.AddComponent<Controller>();

            GameObject settingsMenuGameObject = new GameObject();
            character.GetComponent<SettingsMenu>().settingsMenu = settingsMenuGameObject;

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

            GameObject audioGameObject = new GameObject();
            var audio = audioGameObject.AddComponent<AudioSource>();
            character.jumpAudio = audio;
            character.dashAudio = audio;

            GameObject abilityPoint1 = new GameObject();
            GameObject abilityPoint2 = new GameObject();
            GameObject habilityPoint3 = new GameObject();
            GameObject noAbilityPoint1 = new GameObject();
            GameObject noAbilityPoint2 = new GameObject();
            GameObject noAbilityPoint3 = new GameObject();

            character.gameObject.GetComponent<Ability>().abilityPoint1 = abilityPoint1;
            character.gameObject.GetComponent<Ability>().abilityPoint2 = abilityPoint2;
            character.gameObject.GetComponent<Ability>().abilityPoint3 = habilityPoint3;
            character.gameObject.GetComponent<Ability>().noAbilityPoint1 = noAbilityPoint1;
            character.gameObject.GetComponent<Ability>().noAbilityPoint2 = noAbilityPoint2;
            character.gameObject.GetComponent<Ability>().noAbilityPoint3 = noAbilityPoint3;

            yield return null;

            //Can use ability -> Is not using ability
            Assert.True(character.gameObject.GetComponent<Ability>().CanUseAbility());

            //Dash: 0.35 seconds using ability and 0.35 seconds cooldown
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

            //Heal: 0 seconds using ability and 0.35 seconds cooldown
            character.gameObject.GetComponent<Ability>().UseAbility(Character.Heal);

            yield return new WaitForSeconds(0.2f);

            //Can't use ability -> Ability is cooldown
            Assert.False(character.gameObject.GetComponent<Ability>().CanUseAbility());

            yield return new WaitForSeconds(0.2f);

            //Can use ability -> Is not using ability
            Assert.True(character.gameObject.GetComponent<Ability>().CanUseAbility());
        }

        [UnityTest]
        public IEnumerator AbilityPoints()
        {
            var gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.gameObject.AddComponent<Rigidbody2D>();
            character.gameObject.AddComponent<Animator>();
            character.gameObject.AddComponent<SpriteRenderer>();
            character.gameObject.AddComponent<Ability>();
            character.gameObject.AddComponent<CharacterControl>();
            character.gameObject.AddComponent<SettingsMenu>();
            character.gameObject.AddComponent<Controller>();

            GameObject settingsMenuGameObject = new GameObject();
            character.GetComponent<SettingsMenu>().settingsMenu = settingsMenuGameObject;

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

            GameObject audioGameObject = new GameObject();
            var audio = audioGameObject.AddComponent<AudioSource>();
            character.jumpAudio = audio;
            character.dashAudio = audio;

            GameObject abilityPoint1 = new GameObject();
            GameObject abilityPoint2 = new GameObject();
            GameObject habilityPoint3 = new GameObject();
            GameObject noAbilityPoint1 = new GameObject();
            GameObject noAbilityPoint2 = new GameObject();
            GameObject noAbilityPoint3 = new GameObject();

            character.gameObject.GetComponent<Ability>().abilityPoint1 = abilityPoint1;
            character.gameObject.GetComponent<Ability>().abilityPoint2 = abilityPoint2;
            character.gameObject.GetComponent<Ability>().abilityPoint3 = habilityPoint3;
            character.gameObject.GetComponent<Ability>().noAbilityPoint1 = noAbilityPoint1;
            character.gameObject.GetComponent<Ability>().noAbilityPoint2 = noAbilityPoint2;
            character.gameObject.GetComponent<Ability>().noAbilityPoint3 = noAbilityPoint3;

            yield return null;

            //3 abilityPoints, 0 noAbilityPoints
            Assert.True(character.gameObject.GetComponent<Ability>().abilityPoint1.activeSelf);
            Assert.True(character.gameObject.GetComponent<Ability>().abilityPoint2.activeSelf);
            Assert.True(character.gameObject.GetComponent<Ability>().abilityPoint3.activeSelf);
            Assert.False(character.gameObject.GetComponent<Ability>().noAbilityPoint1.activeSelf);
            Assert.False(character.gameObject.GetComponent<Ability>().noAbilityPoint2.activeSelf);
            Assert.False(character.gameObject.GetComponent<Ability>().noAbilityPoint3.activeSelf);

            character.gameObject.GetComponent<Ability>().UseAbility(Character.Dash);
            yield return new WaitForSeconds(0.4f);

            //2 abilityPoints, 1 noAbilityPoints
            Assert.False(character.gameObject.GetComponent<Ability>().abilityPoint1.activeSelf);
            Assert.True(character.gameObject.GetComponent<Ability>().abilityPoint2.activeSelf);
            Assert.True(character.gameObject.GetComponent<Ability>().abilityPoint3.activeSelf);
            Assert.True(character.gameObject.GetComponent<Ability>().noAbilityPoint1.activeSelf);
            Assert.False(character.gameObject.GetComponent<Ability>().noAbilityPoint2.activeSelf);
            Assert.False(character.gameObject.GetComponent<Ability>().noAbilityPoint3.activeSelf);

            character.gameObject.GetComponent<Ability>().UseAbility(Character.Dash);
            yield return new WaitForSeconds(0.4f);

            //1 abilityPoints, 2 noAbilityPoints
            Assert.False(character.gameObject.GetComponent<Ability>().abilityPoint1.activeSelf);
            Assert.False(character.gameObject.GetComponent<Ability>().abilityPoint2.activeSelf);
            Assert.True(character.gameObject.GetComponent<Ability>().abilityPoint3.activeSelf);
            Assert.True(character.gameObject.GetComponent<Ability>().noAbilityPoint1.activeSelf);
            Assert.True(character.gameObject.GetComponent<Ability>().noAbilityPoint2.activeSelf);
            Assert.False(character.gameObject.GetComponent<Ability>().noAbilityPoint3.activeSelf);

            character.gameObject.GetComponent<Ability>().UseAbility(Character.Dash);
            yield return new WaitForSeconds(0.4f);

            //0 abilityPoints, 3 noAbilityPoints
            Assert.False(character.gameObject.GetComponent<Ability>().abilityPoint1.activeSelf);
            Assert.False(character.gameObject.GetComponent<Ability>().abilityPoint2.activeSelf);
            Assert.False(character.gameObject.GetComponent<Ability>().abilityPoint3.activeSelf);
            Assert.True(character.gameObject.GetComponent<Ability>().noAbilityPoint1.activeSelf);
            Assert.True(character.gameObject.GetComponent<Ability>().noAbilityPoint2.activeSelf);
            Assert.True(character.gameObject.GetComponent<Ability>().noAbilityPoint3.activeSelf);

            character.gameObject.GetComponent<Ability>().ResetAbility();

            //3 abilityPoints, 0 noAbilityPoints
            Assert.True(character.gameObject.GetComponent<Ability>().abilityPoint1.activeSelf);
            Assert.True(character.gameObject.GetComponent<Ability>().abilityPoint2.activeSelf);
            Assert.True(character.gameObject.GetComponent<Ability>().abilityPoint3.activeSelf);
            Assert.False(character.gameObject.GetComponent<Ability>().noAbilityPoint1.activeSelf);
            Assert.False(character.gameObject.GetComponent<Ability>().noAbilityPoint2.activeSelf);
            Assert.False(character.gameObject.GetComponent<Ability>().noAbilityPoint3.activeSelf);
        }

        [UnityTest]
        public IEnumerator Heal()
        {
            var gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.gameObject.AddComponent<Rigidbody2D>();
            character.gameObject.AddComponent<Animator>();
            character.gameObject.AddComponent<SpriteRenderer>();
            character.gameObject.AddComponent<Ability>();
            character.gameObject.AddComponent<CharacterControl>();
            character.gameObject.AddComponent<SettingsMenu>();
            character.gameObject.AddComponent<Controller>();

            GameObject settingsMenuGameObject = new GameObject();
            character.GetComponent<SettingsMenu>().settingsMenu = settingsMenuGameObject;

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

            GameObject abilityPoint1 = new GameObject();
            GameObject abilityPoint2 = new GameObject();
            GameObject habilityPoint3 = new GameObject();
            GameObject noAbilityPoint1 = new GameObject();
            GameObject noAbilityPoint2 = new GameObject();
            GameObject noAbilityPoint3 = new GameObject();

            character.gameObject.GetComponent<Ability>().abilityPoint1 = abilityPoint1;
            character.gameObject.GetComponent<Ability>().abilityPoint2 = abilityPoint2;
            character.gameObject.GetComponent<Ability>().abilityPoint3 = habilityPoint3;
            character.gameObject.GetComponent<Ability>().noAbilityPoint1 = noAbilityPoint1;
            character.gameObject.GetComponent<Ability>().noAbilityPoint2 = noAbilityPoint2;
            character.gameObject.GetComponent<Ability>().noAbilityPoint3 = noAbilityPoint3;

            yield return null;

            character.Damage();
            character.Damage();

            //1 Heart, 2 noHearts
            Assert.False(character.heart1.activeSelf);
            Assert.False(character.heart2.activeSelf);
            Assert.True(character.heart3.activeSelf);
            Assert.True(character.noHeart1.activeSelf);
            Assert.True(character.noHeart2.activeSelf);
            Assert.False(character.noHeart3.activeSelf);

            character.SetAction(Character.Heal);
            yield return new WaitForSeconds(0.1f);

            //2 Hearts, 1 noHeart
            Assert.False(character.heart1.activeSelf);
            Assert.True(character.heart2.activeSelf);
            Assert.True(character.heart3.activeSelf);
            Assert.True(character.noHeart1.activeSelf);
            Assert.False(character.noHeart2.activeSelf);
            Assert.False(character.noHeart3.activeSelf);


            character.SetAction(Character.Heal);
            yield return new WaitForSeconds(0.1f);

            //3 Hearts, 0 noHearts
            Assert.True(character.heart1.activeSelf);
            Assert.True(character.heart2.activeSelf);
            Assert.True(character.heart3.activeSelf);
            Assert.False(character.noHeart1.activeSelf);
            Assert.False(character.noHeart2.activeSelf);
            Assert.False(character.noHeart3.activeSelf);

            character.SetAction(Character.Heal);
            yield return new WaitForSeconds(0.1f);

            //Maximum hearts is 3 -> 3 Hearts, 0 noHearts
            Assert.True(character.heart1.activeSelf);
            Assert.True(character.heart2.activeSelf);
            Assert.True(character.heart3.activeSelf);
            Assert.False(character.noHeart1.activeSelf);
            Assert.False(character.noHeart2.activeSelf);
            Assert.False(character.noHeart3.activeSelf);
        }
    }
}
