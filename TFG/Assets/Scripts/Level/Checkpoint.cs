using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform checkpointPosition;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = FindObjectOfType<Character>();
        character.setRespawnPosition(checkpointPosition.position);
    }
}
