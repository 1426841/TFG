using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    public SaveSystem saveSystem;
    public TextMesh textMesh;
    public int level;

    void Start()
    {
        textMesh.text = saveSystem.GetLevelTime(level);
    }
}
