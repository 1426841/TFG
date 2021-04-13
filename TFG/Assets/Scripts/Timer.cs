using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    private float initialTime;
    private float totalTime;

    void Start()
    {
        timerText = GetComponent<Text>();
        initialTime = Time.time;
        totalTime = 0;
    }

    public float GetTotalTime()
    {
        return totalTime;
    }

    void Update()
    {
        totalTime = Time.time - initialTime;

        timerText.text = totalTime.ToString();
    }
}
