using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    private const string EnemyCollider = "EnemyCollider";
    private const string Enemy = "Enemy";

    public static bool isColliding;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.isTrigger && collider.name != EnemyCollider && collider.name != Enemy)
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
