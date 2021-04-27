using UnityEngine;

public class HorizontalMovingPlatform : MonoBehaviour
{
    private const float PlatformSpeed = 3;

    public Transform InitialPosition;
    public Transform FinalPosition;
    private Vector3 movePosition;

    void Start()
    {
        movePosition = InitialPosition.position;   
    }

    void Update()
    {
        if (transform.position == InitialPosition.position)
        {
            movePosition = FinalPosition.position;
        } else if (transform.position == FinalPosition.position)
        {
            movePosition = InitialPosition.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, movePosition, PlatformSpeed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }
}
