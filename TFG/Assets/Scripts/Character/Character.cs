using UnityEngine;

public class Character :  MonoBehaviour
{
    public const string MoveRight = "moveRight";
    public const string MoveLeft = "moveLeft";
    public const string NoMove = "noMove";
    private const float Speed = 7;

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
        switch (action)
        {
            case MoveRight:
                rigidBody.velocity = new Vector2(Speed, rigidBody.velocity.y);
                break;
            case MoveLeft:
                rigidBody.velocity = new Vector2(-Speed, rigidBody.velocity.y);
                break;
            case NoMove:
                rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
                break;
            default:
                Debug.LogWarning("Wrong character action!");
                break;
        }
    }
}
