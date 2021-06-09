using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMenu : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI textCoin;

    // Start is called before the first frame update
    void Start()
    {
        textCoin.text = DataStorage.playerData.coins.ToString("D2");
    }


}
