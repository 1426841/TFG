using UnityEngine;

public class Character :  MonoBehaviour
{
    public const string MoveRight = "moveRight";
    public const string MoveLeft = "moveLeft";
    public const string NoMove = "noMove";
    public const string Jump = "jump";
    public const string Respawn = "respawn";
    public const string Dash = "dash";
    public const string Heal = "heal";
    private const string IsMoving = "isMoving";
    private const string IsJumping = "isJumping";
    private const float Speed = 7;
    private const float NoSpeed = 0;
    private const float JumpSpeed = 8;
    private const float InitialPositionX = -7;
    private const float InitialPositionY = -3;
    private const float InitialPositionZ = 0;
    private const int MaxHearts = 3;

    public GameObject heart1, heart2, heart3, noHeart1, noHeart2, noHeart3;
    public AudioSource jumpAudio;
    public AudioSource dashAudio;
    private Rigidbody2D rigidBody;
    private string action;
    private SpriteRenderer characterSpriteRenderer;
    private Animator characterAnimator;
    private int hearts;
    private Camera camera;
    private Vector3 respawnPosition;
    private Ability ability;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        action = NoMove;
        characterSpriteRenderer = GetComponent<SpriteRenderer>();
        characterAnimator = GetComponent<Animator>();
        hearts = MaxHearts;
        ActivateHearts(true, true, true, false, false, false);
        camera = FindObjectOfType<Camera>();
        respawnPosition = new Vector3(InitialPositionX, InitialPositionY, InitialPositionZ);
        ability = GetComponent<Ability>();
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

        // Performs the selected action in CharacterControl
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
                if (!jumpAudio.isPlaying)
                {
                    jumpAudio.Play();
                }
                break;
            case Respawn:
                rigidBody.transform.position = respawnPosition;
                hearts = MaxHearts;
                ability.ResetAbility();
                ActivateHearts(true, true, true, false, false, false);
                break;
            case Dash:
                characterAnimator.SetBool(IsJumping, true);
                if (!dashAudio.isPlaying)
                {
                    dashAudio.Play();
                }

                // Dash goes to the right or to the left depending on the initial orientation of the character
                if (characterSpriteRenderer.flipX == false)
                {
                    rigidBody.velocity = new Vector2(Speed * 2, 0);
                }
                else
                {
                    rigidBody.velocity = new Vector2(-Speed * 2, 0);
                }
                break;
            case Heal:
                HealHearts();
                break;
            default:
                Debug.LogWarning("Wrong character action!");
                break;
        }

        if (CharacterCollider.isColliding && action != Dash && action != Jump)
        {
            // When the character is colliding and doesnt jump or dashes, disables jumping animation
            characterAnimator.SetBool(IsJumping, false);
        } else {
            // When the character jumps or dashes, disables moving animation
            characterAnimator.SetBool(IsMoving, false);
        }
    }

    private void LateUpdate()
    {
        // The camera follows the character
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

    public void setRespawnPosition(Vector3 respawnPosition)
    {
        this.respawnPosition = respawnPosition;
    }

    private void HealHearts()
    {
        if (hearts < MaxHearts)
        {
            hearts = ++hearts;
        }

        if (hearts == MaxHearts)
        {
            ActivateHearts(true, true, true, false, false, false);
        } else {
            ActivateHearts(false, true, true, true, false, false);
        }
    }
}
