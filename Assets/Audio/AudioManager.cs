using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource SFXSource;
    public AudioClip swordsound1;
    public AudioClip swordsound2;
    public AudioClip swordsound3;
    public AudioClip potionsound;
    public AudioClip hurtsound;
    public AudioClip deathsound;

    public static AudioManager instance {get; private set;}

    //make singleton and prevent keep cross-scene
    private void Awake() {
        if(instance != null){
            Debug.Log("Found more than one Audio Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}