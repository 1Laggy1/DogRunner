using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public float timeStart = 0;
    public float second1;
    public float second2;
    public float secondF;
    public Text timerText;
    public float timeFinish;
    public float timeStop;

    void Start()
    {
        timerText.text = timeStart.ToString();
        
    }

    void Update()
    {
        if (Time.deltaTime != null)
        {
            timeStart += Time.deltaTime;
            timeFinish = timeStart - timeStop;
            second1 = timeFinish * 100;
            second2 = Mathf.Round(second1);
            secondF = second2 / 100;
            timerText.text = secondF.ToString();
        }
        
    }
}