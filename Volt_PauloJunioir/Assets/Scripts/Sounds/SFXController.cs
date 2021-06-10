using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{

    public static SFXController instance;

    public AudioSource Audio;

    public string SFXTag = "SFX";


    public AudioClip gameOverClip;

    public AudioClip winClip;

    public AudioClip transitionClip;



    private void Awake()
    {


        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;

        }


        instance = this;

        if(SFXTag != null)
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



    public void PlayClipLoop(AudioClip clip, bool stop)
    {

        if (!stop && !Audio.isPlaying)
        {
        
            Audio.clip = clip;
            Audio.loop = true;
            Audio.Play();
        }
        else if (stop && Audio.isPlaying)
        {
            if(Audio.clip == clip)
            {
                Audio.loop = false;
                Audio.Stop();
            }
        }


    }




}
