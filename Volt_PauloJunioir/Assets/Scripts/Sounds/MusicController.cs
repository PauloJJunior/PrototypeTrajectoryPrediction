using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is responsible for controlling the music in the game
public class MusicController : MonoBehaviour
{

    // Declare a static instance
    public static MusicController instance;

   
    public AudioSource Audio;


    private void Awake()
    {

        // Tests if the class has already been instantiated, in addition to not destroying the current instance.
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;

        }

        instance = this;

        // Set AudioSource
        Audio = this.GetComponent<AudioSource>();
        DontDestroyOnLoad(this);

    }
}
