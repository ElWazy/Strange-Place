using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    private TextMeshProUGUI countdownTimer;
    private float timeValue;

    void Start()
    {
       countdownTimer = GetComponent<TextMeshProUGUI>(); 
       timeValue = 0;
    }

    void Update()
    {
        timeValue += Time.deltaTime;
        int msec = (int)((timeValue - (int)timeValue) * 100);
        int sec = (int)(timeValue % 60);
        int min = (int)(timeValue / 60 % 60);

        countdownTimer.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);
    }
}
