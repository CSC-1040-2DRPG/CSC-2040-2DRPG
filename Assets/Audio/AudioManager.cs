using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource SFXSource;
    public AudioClip swordswoosh;
    public AudioClip swordsound1;
    public AudioClip swordsound2;
    public AudioClip swordsound3;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}