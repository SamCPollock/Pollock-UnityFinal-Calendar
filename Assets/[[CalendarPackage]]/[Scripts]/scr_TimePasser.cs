using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


//using UnityEngine.Experimental.Rendering.Universal;

public class scr_TimePasser : MonoBehaviour
{
    public float rateOfTimePassage;

    public static float currentHours;
    public static float currentMinutes;
    public static float currentSeconds;
    public static float currentDay;

    public static event UnityAction<float> hourPassedEvent;
    public static event UnityAction<float> dayPassedEvent;

    public float startingDay;
    private TextMeshProUGUI timeDisplay;
    private scr_Calendar calendar;


    private void Start()
    {
        timeDisplay = GameObject.Find("Time").GetComponentInChildren<TextMeshProUGUI>();
        calendar = GameObject.Find("Calendar").GetComponent<scr_Calendar>();

        currentDay = startingDay;
        currentHours = 0;
        currentMinutes = 0;
        currentSeconds = 0;

        dayPassedEvent?.Invoke(currentDay);



    }

    private void FixedUpdate()
    {
        AddTime();
    }


    private void AddTime()
    {
        currentSeconds += (Time.deltaTime * rateOfTimePassage);

        if (currentSeconds >= 10)
        {
            currentSeconds = 0;
            currentMinutes++;
        }
        if (currentMinutes >= 10)
        {
            currentMinutes = 0;
            currentHours++;
 
            hourPassedEvent?.Invoke(currentHours);
        }
        if (currentHours >= 24)
        {
            currentHours = 0;
            currentDay++;
            if (currentDay > 27)
            {
                currentDay = 0;
            }
       
            dayPassedEvent?.Invoke(currentDay);
        }


        string fullTime = "TIME: " + currentHours.ToString("00") + ":" + currentMinutes.ToString("00") + ":" + ((int)currentSeconds).ToString("00");
        timeDisplay.text = fullTime;

    }

}





