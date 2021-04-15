using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    private float initialTime;
    private float totalTime;
    private bool isFinish;

    void Start()
    {
        timerText = GetComponent<Text>();
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

            float minutes = (int)totalTime / 60;
            float seconds = totalTime % 60;

            timerText.text = minutes.ToString() + ":" + seconds.ToString("f1");
        } 
    }

    public void SaveTime()
    {
        SaveSystem saveSystem = new SaveSystem();
        saveSystem.Save(timerText.text);
    }
}
