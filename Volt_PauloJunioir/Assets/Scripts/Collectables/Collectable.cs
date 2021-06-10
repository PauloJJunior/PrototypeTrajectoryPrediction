using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is used on all collectibles.
public class Collectable : MonoBehaviour
{

    //Creates a CollectablesScriptable variable
    public CollectablesScriptable CollectablePresets;


    //Return the CollectablesScriptable and destroy the collectable
    public CollectablesScriptable Collected()
    {

        Destroy(this.gameObject);
        return CollectablePresets;
    }
}
