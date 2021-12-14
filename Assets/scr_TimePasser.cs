using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.Experimental.Rendering.Universal;

public class scr_TimePasser : MonoBehaviour
{
    public float rateOfTimePassage;

    public static float currentHours;
    public static float currentMinutes;
    public static float currentSeconds;
    public static float currentDay;

    private TextMeshProUGUI timeDisplay;
    //private Light2D globalLight; 


    private void Start()
    {
        timeDisplay = GameObject.Find("Time").GetComponentInChildren<TextMeshProUGUI>();
        //globalLight = GameObject.Find("Global Light 2D").GetComponent<Light2D>();


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
            SetTimeOfDay();
        }
        if (currentHours >= 24)
        {
            currentHours = 0;
            currentDay++;
            scr_Calendar.currentDay++;
            scr_Calendar.SetCurrentDay();
        }


        string fullTime = "TIME: " + currentHours.ToString("00") + ":" + currentMinutes.ToString("00") + ":" + ((int)currentSeconds).ToString("00");
        timeDisplay.text = fullTime;

    }

    private void SetTimeOfDay()
    {
        float distanceFromNoon = Mathf.Abs(currentHours - 12);
        scr_DayManager.SetLightBrightness(1 - (distanceFromNoon / 12));
        //if (currentHours == 0)          // Midnight
        //{
        //    globalLight.color = Color.grey;
        //}
        //else if (currentHours == 6)     // Morning
        //{
        //    globalLight.color = Color.magenta;

        //}
        //else if (currentHours == 12)    // Noon
        //{
        //    globalLight.color = Color.yellow;

        //}
        //else if (currentHours == 18)    // Evening
        //{
        //    globalLight.color = Color.blue;
        //}
    }

}





