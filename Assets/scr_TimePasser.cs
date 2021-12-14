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

    //public delegate void timeDelegate();
    //public timeDelegate hourPassed;

//    public static event UnityAction myStaticEvent;
    public static event UnityAction<float> hourPassedEvent;
    public static event UnityAction<float> dayPassedEvent;

    public float startingDay;
    private TextMeshProUGUI timeDisplay;
    private scr_Calendar calendar;
    //private Light2D globalLight; 


    private void Start()
    {
        timeDisplay = GameObject.Find("Time").GetComponentInChildren<TextMeshProUGUI>();
        calendar = GameObject.Find("Calendar").GetComponent<scr_Calendar>();
        //globalLight = GameObject.Find("Global Light 2D").GetComponent<Light2D>();

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

        if (currentSeconds >= 1)
        {
            currentSeconds = 0;
            currentMinutes++;
        }
        if (currentMinutes >= 1)
        {
            currentMinutes = 0;
            currentHours++;
            //SetTimeOfDay();

            //hourPassed?.Invoke();
            hourPassedEvent?.Invoke(currentHours);
        }
        if (currentHours >= 24)
        {
            currentHours = 0;
            currentDay++;
            //scr_Calendar.currentDay++;
            //calendar.SetCurrentDay();
            dayPassedEvent?.Invoke(currentDay);
        }


        string fullTime = "TIME: " + currentHours.ToString("00") + ":" + currentMinutes.ToString("00") + ":" + ((int)currentSeconds).ToString("00");
        timeDisplay.text = fullTime;

    }

    private void SetTimeOfDay()
    {

    }

}





