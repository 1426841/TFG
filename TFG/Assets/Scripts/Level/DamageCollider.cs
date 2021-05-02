using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private const float MaxTimeStay = 2;

    private float timeStayed;
    private Character character;

    private void Start()
    {
        character = FindObjectOfType<Character>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {    
        character.Damage();
        timeStayed = 0;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (timeStayed < MaxTimeStay)
        {
            timeStayed += Time.deltaTime;
        }
        else
        {
            character.Damage();
            timeStayed = 0;
        }
    }
}
