using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{


    public CollectablesScriptable CollectablePresets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CollectablesScriptable Collected()
    {

      


        return CollectablePresets;
    }
}
