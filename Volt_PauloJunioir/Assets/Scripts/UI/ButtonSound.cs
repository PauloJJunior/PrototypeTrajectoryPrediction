using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{


    // The source of the sound
    private AudioSource soundObject;

    // The index of the current value of the sound
    private float currentState = 1;

    enum soundObjectName { SFXController, MusicController};

    [SerializeField]
    private soundObjectName soundTarget;

    [SerializeField]
    private AudioClip btnAudioClip;


    [SerializeField]
    private Sprite[] sptButtons;




    private Button btn;

    private void Awake()
    {

        if (!soundObject && soundTarget.ToString() != string.Empty)
        {
            if (soundTarget.ToString() == "SFXController")
                soundObject = GameObject.FindGameObjectWithTag(soundTarget.ToString()).gameObject.GetComponent<SFXController>().Audio;

            else
                soundObject = GameObject.FindGameObjectWithTag(soundTarget.ToString()).gameObject.GetComponent<AudioSource>();
        }


    }
    // Start is called before the first frame update
    void Start()
    {

        btn = this.gameObject.GetComponent<Button>();

        // Test to see if the sound is recorded as active or disabled
        if (soundTarget.ToString() == "SFXController") currentState = PlayerPrefs.GetFloat("SFXController", currentState);
        else currentState = PlayerPrefs.GetFloat("MusicController", currentState);

        // Set the sound in the sound source
        SetSound();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SetSound()
    {


        if (!soundObject && soundTarget.ToString() != string.Empty)
        {
            if (soundTarget.ToString() == "SFXController")
            soundObject = GameObject.FindGameObjectWithTag(soundTarget.ToString()).gameObject.GetComponent<SFXController>().Audio;
           
            else
            soundObject = GameObject.FindGameObjectWithTag(soundTarget.ToString()).gameObject.GetComponent<AudioSource>();
        }


        // Update the graphics of the button image to fit the sound state
        if (currentState == 1)
        {
        
            btn.image.sprite = sptButtons[0];
            SpriteState ss = btn.spriteState;
            ss.pressedSprite = sptButtons[1];
            btn.spriteState = ss;
      

        }
        else
        {
       
            btn.image.sprite = sptButtons[2];
            SpriteState ss = btn.spriteState;
            ss.pressedSprite = sptButtons[3];
            btn.spriteState = ss;

        }


      

        // Set the value of the sound state to the source object
        if (soundObject)
            soundObject.volume = currentState;

        // Test to see if the sound is recorded as active or disabled
        if (soundTarget.ToString() == "SFXController")
        {

            PlayerPrefs.SetFloat("SFXController", currentState);

        }
        else
        {

            PlayerPrefs.SetFloat("MusicController", currentState);
    
        }

    }


    public void ToggleSound()
    {
        currentState = 1 - currentState;
       
        SetSound();
        if(btnAudioClip)
        SFXController.instance.PlayClip(btnAudioClip);
    }
}
