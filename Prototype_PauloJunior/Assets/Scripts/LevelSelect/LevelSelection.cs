using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//Class responsible for managing the level select, blocking the levels that are not yet available to the player.
public class LevelSelection : MonoBehaviour
{

    // Set a maxLevel
    [SerializeField]
    private int maxLevel = 1;


    //Buttons for control.
    [SerializeField]
    private Button[] lvlButtons;


    
    void Start()
    {
        // Save the maxLevel in playerData
        if (DataStorage.playerData.maxLevel != maxLevel) DataStorage.playerData.maxLevel = maxLevel;

        //Get the Current Player Level
        int levelAt = DataStorage.playerData.currentLevel;

        //It goes through all the buttons, leaving only those that are level lower than the current player cleared.
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1> levelAt)
            {
                lvlButtons[i].interactable = false;
                lvlButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "X";

            }

        }


    }


}
