using UnityEngine;

public class CollectableCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Character"))
        {
            Collectables collectables = FindObjectOfType<Collectables>();
            collectables.Collect();
            Destroy(gameObject);
        }
    }
}
