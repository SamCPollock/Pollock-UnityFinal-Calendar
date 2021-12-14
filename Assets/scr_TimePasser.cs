using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_TimePasser : MonoBehaviour
{
    public float rateOfTimePassage;

    public static float currentHours;
    public static float currentMinutes;
    public static float currentSeconds;
    public static float currentDay;

    private TextMeshProUGUI timeDisplay;


    private void Start()
    {
        timeDisplay = GameObject.Find("Time").GetComponentInChildren<TextMeshProUGUI>();
        currentHours = 0;
        currentMinutes = 0;
        currentSeconds = 0;


    }

    private void FixedUpdate()
    {
        AddTime();
    }


    private void AddTime()
    {
        currentSeconds += (Time.deltaTime * rateOfTimePassage);

        if (currentSeconds >= 60)
        {
            currentSeconds = 0;
            currentMinutes++;
        }
        if (currentMinutes >= 60)
        {
            currentMinutes = 0;
            currentHours++;
        }
        if (currentHours >= 60)
        {
            currentHours = 0;
            currentDay++;
        }
        string fullTime = "TIME: " + currentHours.ToString("00") + ":" + currentMinutes.ToString("00") + ":" + ((int)currentSeconds).ToString("00");
        timeDisplay.text = fullTime;
    }
}



