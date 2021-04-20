using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{

    private int totalCollected;
    private Text collectablesText;

    void Start()
    {
        totalCollected = 0;
        collectablesText = GetComponent<Text>();
        collectablesText.text = totalCollected.ToString();
    }

    public string GetCollectablesText()
    {
        return collectablesText.text;
    }

    public void Collect()
    {
        totalCollected ++;
        collectablesText.text = totalCollected.ToString();
    }

}
