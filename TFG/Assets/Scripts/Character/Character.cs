using UnityEngine;

public class Character :  MonoBehaviour
{
    private const float Speed = 7;
    public const string MoveRight = "moveRight";
    public const string MoveLeft = "moveLeft";

    private Rigidbody2D rigidBody;
    private string action;

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void SetAction(string action)
    {
        this.action = action;
    }

    void FixedUpdate()
    {
        if (action == MoveRight)
        {
            rigidBody.velocity = new Vector2(Speed, rigidBody.velocity.y);
        }
        else if (action == MoveLeft)
        {
            rigidBody.velocity = new Vector2(-Speed, rigidBody.velocity.y);
        }
    }
}
