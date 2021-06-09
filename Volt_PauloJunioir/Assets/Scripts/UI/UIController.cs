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
    private Sprite[] sptButtonPause;

    [SerializeField]
    private Button buttonPause;

    [SerializeField]
    private TextMeshProUGUI textCoinGameOver;

    [SerializeField]
    private TextMeshProUGUI textCoinWin;

    public GameObject GameOverObj;

    public GameObject WinObj;

    public GameObject FinishObj;

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


    public void PauseGame()
    {

        gameController.Pause();

        if(gameController.CurrentGameState == GameState.GAMEPLAY)
        {
            buttonPause.image.sprite = sptButtonPause[0];
            SpriteState ss = buttonPause.spriteState;
            ss.pressedSprite = sptButtonPause[1];
            buttonPause.spriteState = ss;
        }
        else
        {
            buttonPause.image.sprite = sptButtonPause[2];
            SpriteState ss = buttonPause.spriteState;
            ss.pressedSprite = sptButtonPause[3];
            buttonPause.spriteState = ss;
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
