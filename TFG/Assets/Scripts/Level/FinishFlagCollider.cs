using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlagCollider : MonoBehaviour
{
    public string scene;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Timer timer = FindObjectOfType<Timer>();
        timer.SetIsFinish(true);
        SaveSystem saveSystem = FindObjectOfType<SaveSystem>();
        saveSystem.Save();
        SceneManager.LoadScene(scene);
    }
}
