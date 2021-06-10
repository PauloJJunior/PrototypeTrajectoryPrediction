using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{

    // Declare a static instance
    public static SFXController instance;

    public AudioSource Audio;

    // Tag SFX
    public string SFXTag = "SFX";

    //Clip GameOver
    public AudioClip gameOverClip;

    //Clip Win
    public AudioClip winClip;

    //Clip Button Transition
    public AudioClip transitionClip;



    private void Awake()
    {

        // Tests if the class has already been instantiated
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;

        }

        instance = this;


        //Search for audio source responsible for SFX
        if (SFXTag != null)
        Audio = GameObject.FindGameObjectWithTag(SFXTag).transform.GetComponent<AudioSource>();
       

    }


    //Play Audio Clip
    public void PlayClip(AudioClip clip)
    {
        Audio.PlayOneShot(clip);
    }



    //Play Audio Clip plus volume
    public void PlayClip(AudioClip clip, float volume)
    {
        Audio.PlayOneShot(clip, volume);
    }



    //Play Audio Clip plus volume and audioSource
    public void PlayClip(AudioClip clip, float volume, AudioSource audioSource)
    {
        audioSource.PlayOneShot(clip, volume);
    }



    //Play Audio in loop or stoop loop
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
