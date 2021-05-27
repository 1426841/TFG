using UnityEngine;

public class LevelBarrier : MonoBehaviour
{
    public GameObject barrier;
    public int levelRequired;
    public SaveSystem saveSystem;

    void Start()
    {
        if (levelRequired <= saveSystem.getCompletedLevels())
        {
            barrier.gameObject.SetActive(false);
        }
    }
}
