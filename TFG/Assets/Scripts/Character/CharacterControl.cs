using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public const float RespawnPosition = -5;
    
    private Controller controller;
    private Character character;
    private string action;
    private Ability ability;

    void Start()
    {
        controller = new Controller();
        character = GetComponent<Character>();
        ability = GetComponent<Ability>();
    }

    void FixedUpdate()
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

        if (Input.GetKey(controller.GetJump()) && CharacterCollider.isColliding)
        {
            action = Character.Jump;
        }

        if (Input.GetKey(controller.GetDash()) && ability.CanUseAbility())
        {
            ability.UseAbility(Character.Dash);
            action = Character.Dash;
        }

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
