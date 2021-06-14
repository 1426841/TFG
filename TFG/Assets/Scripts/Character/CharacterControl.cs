using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public const float RespawnPosition = -5;
    
    private Controller controller;
    private Character character;
    private string action;
    private Ability ability;
    private SettingsMenu settingsMenu;

    void Start()
    {
        controller = FindObjectOfType<Controller>();
        character = GetComponent<Character>();
        ability = GetComponent<Ability>();
        settingsMenu = FindObjectOfType<SettingsMenu>();
        settingsMenu.OpenCloseSettings();
    }

    private void Update()
    {
        if (Input.GetKeyDown(controller.GetSettingsMenu()))
        {
            settingsMenu.OpenCloseSettings();
        }
    }

    void FixedUpdate()
    {
        if (!settingsMenu.isOpenSettings())
        {
            if (Input.GetKey(controller.GetRight()))
            {
                action = Character.MoveRight;
            }
            else if (Input.GetKey(controller.GetLeft()))
            {
                action = Character.MoveLeft;
            }
            else
            {
                action = Character.NoMove;
            }

            // The character can only jump when he collides with something
            if (Input.GetKey(controller.GetJump()) && CharacterCollider.isColliding)
            {
                action = Character.Jump;
            }

            if (Input.GetKey(controller.GetDash()) && ability.CanUseAbility())
            {
                ability.UseAbility(Character.Dash);
                action = Character.Dash;
            }

            // If the ability is still being used, keeps the ability as the current action
            if (ability.IsUsingAbility())
            {
                action = ability.GetAbility();
            }

            if (character.transform.position.y < RespawnPosition)
            {
                action = Character.Respawn;
                ability.ResetAbility();
            }

            character.SetAction(action);
        }
    }
}
