using UnityEngine;

public class HorizontalMovingObject : MonoBehaviour
{
    private const float ObjectSpeed = 3;

    public Transform InitialPosition;
    public Transform FinalPosition;
    public Vector3 movePosition;


    protected virtual void Start()
    {
        movePosition = InitialPosition.position;
    }

    protected virtual void FixedUpdate()
    {
        if (transform.position == InitialPosition.position)
        {
            movePosition = FinalPosition.position;
        }
        else if (transform.position == FinalPosition.position)
        {
            movePosition = InitialPosition.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, movePosition, ObjectSpeed * Time.deltaTime);
    }
}
