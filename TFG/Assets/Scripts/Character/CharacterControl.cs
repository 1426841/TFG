using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Controller controller;
    private Character character;
    private string action;

    void Start()
    {
        controller = new Controller();
        character = GetComponent<Character>();
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

        if (Input.GetKey("space") && CharacterCollider.isColliding)
        {
            action = Character.Jump;
        }

        character.SetAction(action);
    }
}
