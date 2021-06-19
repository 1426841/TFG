using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string scene;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        SceneManager.LoadScene(scene);
    }
}
