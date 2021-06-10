using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//This class is responsible for controlling the Start Menu UI.
public class UIMenu : MonoBehaviour
{

    //Variable Text Coin in UI
    [SerializeField]
    private TextMeshProUGUI textCoin;

    // Start is called before the first frame update
    void Start()
    {
        //Updating the coins with playrData
        textCoin.text = DataStorage.playerData.coins.ToString("D2");
    }


}
