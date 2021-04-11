using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    public static bool isColliding;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        isColliding = false;
    }
}
