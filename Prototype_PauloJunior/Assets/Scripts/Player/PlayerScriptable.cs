using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is responsible for creating the player in the inspector and defining its values.
[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class PlayerScriptable : ScriptableObject
{

    //Player Name
    public string Name;

    //Player Drag
    public float Drag;

    //Force Multiplier
    public float ForceMultiplier;

    // Life for seconds
    public float LifeSeconds;

    // Life for seconds
    public float Life;

    //Efect Jump
    public GameObject JumpEffect;

    //Sound Effect Drag
    public AudioClip DragClip;

    //Sound Effect Jump
    public AudioClip JumpClip;

    //Sound Effect Jump
    public AudioClip HitClip;

    //Color No Life Color
    public Color noLifeCenterMaterial;
}
