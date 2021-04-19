using UnityEngine;

public class FinishFlagCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Timer timer = FindObjectOfType<Timer>();
        timer.SetIsFinish(true);
        timer.SaveTime();
        Character character = FindObjectOfType<Character>();
        character.SetAction(Character.Respawn);
        timer.ResetTime();
    }
}
