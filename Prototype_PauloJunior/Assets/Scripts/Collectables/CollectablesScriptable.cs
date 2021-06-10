using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is responsible for creating the collectable in the inspector and defining its values.
[CreateAssetMenu(fileName = "New Collectable", menuName = "Collectable")]
public class CollectablesScriptable : ScriptableObject
{

    //Type Collectable
    public TypeCollectable Type;

    //Quantity Life
    public float LifeRestoure;

    //Coins
    public int Coins;

    //Sound Effect Collect
    public AudioClip CollectClip;


}
