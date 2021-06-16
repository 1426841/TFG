using UnityEngine;

public class MovingObject : MonoBehaviour
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
        // The object repeatedly moves from the InitialPosition to the FinalPosition and vice versa
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
