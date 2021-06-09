using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{

    [SerializeField]
    private int maxLevel;


    [SerializeField]
    private Button[] lvlButtons;


    // Start is called before the first frame update
    void Start()
    {

        if (DataStorage.playerData.maxLevel != maxLevel) DataStorage.playerData.maxLevel = maxLevel;

        int levelAt = DataStorage.playerData.currentLevel;

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1> levelAt)
            {
                lvlButtons[i].interactable = false;
                lvlButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "X";

            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
