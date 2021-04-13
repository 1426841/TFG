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

    public string GetTimerText()
    {
        return timerText.text;
    }

    void Update()
    {
        totalTime = Time.time - initialTime;

        float minutes = (int) totalTime / 60;
        float seconds = totalTime % 60;

        timerText.text = minutes.ToString() + ":" + seconds.ToString("f2");
    }
}
