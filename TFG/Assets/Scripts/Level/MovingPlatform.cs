using UnityEngine;

public class MovingPlatform : MovingObject
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // The character moves along with the platform
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }
}
