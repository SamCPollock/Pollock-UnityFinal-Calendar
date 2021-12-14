using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> footstepSoundClips;

    [SerializeField]
    private AudioClip sleighBellsSound;

    [SerializeField]
    private AudioSource soundSource;

    [SerializeField] 
    private float pitchVariance = 0.15f;

    public bool isInSnow = false;

    void PlayRandomFootsep()
    {
        if (isInSnow)
        {
            soundSource.clip = sleighBellsSound;
            soundSource.Play();
        }
        else
        {
            soundSource.clip = footstepSoundClips[Random.Range(0, footstepSoundClips.Count)];
            soundSource.pitch = 1.0f + Random.Range(-pitchVariance, pitchVariance);
        }
            soundSource.Play();
    }
}
