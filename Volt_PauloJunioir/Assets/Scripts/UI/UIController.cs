using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textCoin;


    [SerializeField]
    private Image imgPlayer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void setCoin(int coin)
    {
        textCoin.text = coin.ToString("D2");

    }

    public void setPlayerColor(Color color)
    {

        imgPlayer.color = color;

    }
}
