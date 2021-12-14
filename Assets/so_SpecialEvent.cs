using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DayTraits")]
public class so_SpecialEvent : ScriptableObject
{
    //public int date;
    public Sprite dayImage;

    public Color dayLightColor;

    public float chanceOfSnow;
    public float chanceOfRain;


    public List<float> hoursToWatchFor = new List<float>();
    public AudioClip soundEffectThatPlaysAtHours;

    //public List<so_SpecialEvent> specialThings = new List<so_SpecialEvent>();

    public void DayStart()
    {
        scr_WeatherManager weatherManager = GameObject.FindObjectOfType<scr_WeatherManager>();
        weatherManager.RollForSnow(chanceOfSnow);
        weatherManager.RollForRain(chanceOfRain);
        scr_DayManager.SetDaylightColor(dayLightColor);

        if (hoursToWatchFor.Count != 0)
        {
            foreach (float hour in hoursToWatchFor)
            {
                scr_DayManager.hoursToWatchFor.Add(hour);
                scr_DayManager.soundEffect = soundEffectThatPlaysAtHours;
            }
        }
    }

    public void DayEnd()
    {
        GameObject.FindObjectOfType<scr_WeatherManager>().snowParticleSystem.SetActive(false);
        GameObject.FindObjectOfType<scr_WeatherManager>().rainParticleSystem.SetActive(false);

        scr_DayManager.hoursToWatchFor.Clear();
        scr_DayManager.soundEffect = null;
        scr_DayManager.SetDaylightColor(Color.white);


    }
}
