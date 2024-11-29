using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;

    public AudioClip swordsound1;
    public AudioClip swordsound2;
    public AudioClip swordsound3;

public void PlaySFX(AudioClip clip){

        SFXSource.PlayOneShot(clip);

    }
}
