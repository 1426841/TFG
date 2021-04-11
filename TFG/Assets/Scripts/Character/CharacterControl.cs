using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Character character;
    private string action;

    void Start()
    {
        character = GetComponent<Character>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
            action = "moveRight";
        }
        character.SetAction(action);
    }
}
