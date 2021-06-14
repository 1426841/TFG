using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    public static bool isColliding;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.isTrigger)
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!collider.isTrigger)
        {
            isColliding = false;
        }
    }
}
