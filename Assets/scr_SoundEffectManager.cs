using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SoundEffectManager : MonoBehaviour
{
    private static AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public static void PlaySoundEffect(AudioClip soundToPlay)
    {
        audioSource.PlayOneShot(soundToPlay);
    }
}
