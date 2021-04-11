using UnityEngine;

public class Character :  MonoBehaviour
{
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
        if (action== "moveRight")
        {
            rigidBody.velocity = new Vector2(Speed, rigidBody.velocity.y);
        }
    }
}
