using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class scr_DayManager : MonoBehaviour
{

    private static Light2D globalLight;

    private void Start()
    {
        globalLight = GameObject.Find("Global Light 2D").GetComponent<Light2D>();

    }

    public static void SetLightBrightness(float brightness)
    {
        globalLight.intensity = brightness;
    }
}
