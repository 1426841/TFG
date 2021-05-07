using UnityEngine;

public class Character :  MonoBehaviour
{
    public const string MoveRight = "moveRight";
    public const string MoveLeft = "moveLeft";
    public const string NoMove = "noMove";
    public const string Jump = "jump";
    public const string Respawn = "respawn";
    public const string Dash = "dash";
    private const string IsMoving = "isMoving";
    private const string IsJumping = "isJumping";
    private const float Speed = 7;
    private const float NoSpeed = 0;
    private const float JumpSpeed = 8;
    private const float InitialPositionX = -7;
    private const float InitialPositionY = -3;
    private const float InitialPositionZ = 0;

    public GameObject heart1, heart2, heart3, noHeart1, noHeart2, noHeart3;
    private Rigidbody2D rigidBody;
    private string action;
    private SpriteRenderer characterSpriteRenderer;
    private Animator characterAnimator;
    private int hearts;
    private Camera camera;

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        action = NoMove;
        characterSpriteRenderer = GetComponent<SpriteRenderer>();
        characterAnimator = GetComponent<Animator>();
        hearts = 3;
        ActivateHearts(true, true, true, false, false, false);
        camera = FindObjectOfType<Camera>();
    }

    public void SetAction(string action)
    {
        this.action = action;
    }

    void FixedUpdate()
    {
        if (hearts < 1)
        {
            action = Respawn;
        }

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
                hearts = 3;
                ActivateHearts(true, true, true, false, false, false);
                break;
            case Dash:
                characterAnimator.SetBool(IsJumping, true);
                if (characterSpriteRenderer.flipX == false)
                {
                    rigidBody.velocity = new Vector2(Speed * 2, 0);
                }
                else
                {
                    rigidBody.velocity = new Vector2(-Speed * 2, 0);
                }
                break;
            default:
                Debug.LogWarning("Wrong character action!");
                break;
        }

        if (CharacterCollider.isColliding && action != Dash)
        {
            characterAnimator.SetBool(IsJumping, false);
        } else {
            characterAnimator.SetBool(IsMoving, false);
        }
    }

    private void LateUpdate()
    {
        camera.transform.position = new Vector3(transform.position.x, 0, -1);
    }

    public void Damage()
    {
        hearts = --hearts;

        if (hearts == 2)
        {
            ActivateHearts(false, true, true, true, false, false);
        }
        else if (hearts == 1)
        {
            ActivateHearts(false, false, true, true, true, false);
        }

    }

    private void ActivateHearts(bool heart1, bool heart2, bool heart3, bool noHeart1, bool noHeart2, bool noHeart3)
    {
        this.heart1.gameObject.SetActive(heart1);
        this.heart2.gameObject.SetActive(heart2);
        this.heart3.gameObject.SetActive(heart3);
        this.noHeart1.gameObject.SetActive(noHeart1);
        this.noHeart2.gameObject.SetActive(noHeart2);
        this.noHeart3.gameObject.SetActive(noHeart3);
    }
}
