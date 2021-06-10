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

    [SerializeField]
    private string gameControllerTag = "GameController";

    private GameController gameController;


    [SerializeField]
    private TextMeshProUGUI textCoinGameOver;

    [SerializeField]
    private TextMeshProUGUI textCoinWin;

    public GameObject GameOverObj;

    public GameObject WinObj;

    public GameObject FinishObj;

    public GameObject PauseObj;

    // Start is called before the first frame update
    void Start()
    {

        gameController = GameObject.FindGameObjectWithTag(gameControllerTag).transform.GetComponent<GameController>();

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


    public void GameOver(int coins)
    {
        GameOverObj.SetActive(true);
        textCoinGameOver.text = coins.ToString("D2");
    }

    public void Win(int coins)
    {
        WinObj.SetActive(true);
        textCoinWin.text = coins.ToString("D2");
    }


    public void PauseGame()
    {

        gameController.Pause();

        if(gameController.CurrentGameState == GameState.GAMEPLAY)
        {
            PauseObj.SetActive(false);
        }
        else
        {
            PauseObj.SetActive(true);
        }

    }

    
    public void NextLevel()
    {
        gameController.NextLevel();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
