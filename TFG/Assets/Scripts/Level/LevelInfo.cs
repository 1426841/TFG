using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    public SaveSystem saveSystem;
    public TextMesh timeTextMesh;
    public TextMesh collectablesTextMesh;
    public int level;

    void Start()
    {
        timeTextMesh.text = saveSystem.GetLevelTime(level);
        collectablesTextMesh.text = saveSystem.GetLevelTotalCollected(level);
    }
}
