using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_WeatherManager : MonoBehaviour
{
    public GameObject snowParticleSystem;
    public GameObject rainParticleSystem;

  
    public void RollForSnow(float chanceOfSnow)
    {
        float random = Random.Range(0, 100);
        if (random <= chanceOfSnow)
        {
            snowParticleSystem.SetActive(true);
        }
    }

    public void RollForRain(float chanceOfRain)
    {
        float random = Random.Range(0, 100);
        if (random <= chanceOfRain)
        {
            rainParticleSystem.SetActive(true);
        }
    }

}
