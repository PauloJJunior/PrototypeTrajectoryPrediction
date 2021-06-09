using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public static MusicController instance;

    public AudioSource Audio;


    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;

        }

        instance = this;
        Audio = this.GetComponent<AudioSource>();
        DontDestroyOnLoad(this);

    }
}
