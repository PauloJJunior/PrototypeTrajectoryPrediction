using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Collectable", menuName = "Collectable")]
public class CollectablesScriptable : ScriptableObject
{

    //Type Collectable
    public TypeCollectable Type;

    //Quantity Life
    public float LifeRestoure;

    //Coins
    public int Coins;


}
