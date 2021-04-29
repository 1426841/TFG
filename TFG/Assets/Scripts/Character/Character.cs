using UnityEngine;

public class Character :  MonoBehaviour
{
    public const string MoveRight = "moveRight";
    public const string MoveLeft = "moveLeft";
    public const string NoMove = "noMove";
    public const string Jump = "jump";
    public const string Respawn = "respawn";
    private const string IsMoving = "isMoving";
    private const string IsJumping = "isJumping";
    private const float Speed = 7;
    private const float NoSpeed = 0;
    private const float JumpSpeed = 8;
    private const float InitialPositionX = -7;
    private const float InitialPositionY = -3;
    private const float InitialPositionZ = 0;

    private Rigidbody2D rigidBody;
    private string action;
    private SpriteRenderer characterSpriteRenderer;
    private Animator characterAnimator;

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        action = NoMove;
        characterSpriteRenderer = GetComponent<SpriteRenderer>();
        characterAnimator = GetComponent<Animator>();
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
                characterSpriteRenderer.flipX = false;
                characterAnimator.SetBool(IsMoving, true);
                break;
            case MoveLeft:
                rigidBody.velocity = new Vector2(-Speed, rigidBody.velocity.y);
                characterSpriteRenderer.flipX = true;
                characterAnimator.SetBool(IsMoving, true);
                break;
            case NoMove:
                rigidBody.velocity = new Vector2(NoSpeed, rigidBody.velocity.y);
                characterAnimator.SetBool(IsMoving, false);
                break;
            case Jump:
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, JumpSpeed);
                characterAnimator.SetBool(IsJumping, true);
                break;
            case Respawn:
                rigidBody.transform.position = new Vector3(InitialPositionX, InitialPositionY, InitialPositionZ);
                break;
            default:
                Debug.LogWarning("Wrong character action!");
                break;
        }

        if (CharacterCollider.isColliding)
        {
            characterAnimator.SetBool(IsJumping, false);
        } else {
            characterAnimator.SetBool(IsMoving, false);
        }
    }
}
