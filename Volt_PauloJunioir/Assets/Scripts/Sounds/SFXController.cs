using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{

    public static SFXController instance;

    public AudioSource Audio;

    public string SFXTag = "SFX";

   

    private void Awake()
    {


        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;

        }


        instance = this;

        Audio = GameObject.FindGameObjectWithTag(SFXTag).transform.GetComponent<AudioSource>();


    }



    public void PlayClip(AudioClip clip)
    {
        Audio.PlayOneShot(clip);
    }


    public void PlayClip(AudioClip clip, float volume)
    {
        Audio.PlayOneShot(clip, volume);
    }


    public void PlayClip(AudioClip clip, float volume, AudioSource audioSource)
    {
        audioSource.PlayOneShot(clip, volume);
    }
}
