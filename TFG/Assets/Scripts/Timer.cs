using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public const string defaultTime = "0:0,0";
    private Text timerText;
    private float initialTime;
    private float totalTime;
    private bool isFinish;

    void Start()
    {
        timerText = GetComponent<Text>();
        timerText.text = defaultTime;
        initialTime = Time.time;
        totalTime = 0;
        isFinish = false;
    }

    public float GetTotalTime()
    {
        return totalTime;
    }

    public string GetTimerText()
    {
        return timerText.text;
    }

    public void SetIsFinish(bool isFinish)
    {
        this.isFinish = isFinish;
    }

    void Update()
    {
        if (!isFinish)
        {
            totalTime = Time.time - initialTime;

            // Converts totalTime to minutes and seconds
            float minutes = (int)totalTime / 60;
            float seconds = totalTime % 60;

            timerText.text = minutes.ToString() + ":" + seconds.ToString("f1");
        }
    }
    
    public void ResetTime()
    {
        initialTime = Time.time;
        isFinish = false;
    }
}
