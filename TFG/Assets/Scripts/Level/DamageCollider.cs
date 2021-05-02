using UnityEngine;

public class DamageCollider : MonoBehaviour
{

    private float timeStayed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Character character = FindObjectOfType<Character>();
            character.Damage();
            timeStayed = 0;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (timeStayed < 2)
        {
            timeStayed += Time.deltaTime;
        }
        else
        {
            Character character = FindObjectOfType<Character>();
            character.Damage();
            timeStayed = 0;
        }
    }
}
