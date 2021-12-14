using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class scr_DayManager : MonoBehaviour
{

    private static Light2D globalLight;

    public static List<float> hoursToWatchFor = new List<float>();

    public static AudioClip soundEffect;


    private void Start()
    {
        globalLight = GameObject.Find("Global Light 2D").GetComponent<Light2D>();

    }


    private void OnEnable()
    {
        scr_TimePasser.hourPassedEvent += HourPassed;
    }

    public static void SetDaylightColor(Color colorToSet)
    {
        globalLight.color = colorToSet;
        //Debug.Log("SETTING COLOR TO " + colorToSet);
    }

    public void HourPassed(float currentHours)
    {
        SetLightBrightness(currentHours);
        if (hoursToWatchFor.Contains(currentHours))
        {
            Debug.Log(currentHours + "IS AN HOUR TO WATCH FOR");
            scr_SoundEffectManager.PlaySoundEffect(soundEffect);
        }
    }

    public static void SetLightBrightness(float currentHours)
    {
        float distanceFromNoon = Mathf.Abs(currentHours - 12);
        globalLight.intensity = (1 - (distanceFromNoon / 12));
        //globalLight.intensity = brightness;
    }

    public void StartDay()
    {

    }
}
