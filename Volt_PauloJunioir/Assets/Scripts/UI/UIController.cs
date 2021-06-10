
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//This class is responsible for controlling the game's UI.
public class UIController : MonoBehaviour
{
    //Variable Text Coin in UI
    [SerializeField]
    private TextMeshProUGUI textCoin;

    //Variable Image Player in UI
    [SerializeField]
    private Image imgPlayer;

    //Tag GameController
    [SerializeField]
    private string gameControllerTag = "GameController";

    // Local gameController
    private GameController gameController;

    //Variable Text Coin in GameOver
    [SerializeField]
    private TextMeshProUGUI textCoinGameOver;

    //Variable Text Coin in Win
    [SerializeField]
    private TextMeshProUGUI textCoinWin;

    //Game Object responsible for showing GameOver
    public GameObject GameOverObj;

    //Game Object responsible for showing Win
    public GameObject WinObj;

    //Game Object responsible for showing Finish
    public GameObject FinishObj;

    //Game Object responsible for showing Pause
    public GameObject PauseObj;

    // Start is called before the first frame update
    void Start()
    {
        // search the gameController  for the tag
        gameController = GameObject.FindGameObjectWithTag(gameControllerTag).transform.GetComponent<GameController>();

    }


    //Show Coin in UI
    public void setCoin(int coin)
    {
        textCoin.text = coin.ToString("D2");

    }

    //Show Player Color in  UI
    public void setPlayerColor(Color color)
    {

        imgPlayer.color = color;

    }


    //Show  Game Object responsible for showing GameOver and updating the coins
    public void GameOver(int coins)
    {
        GameOverObj.SetActive(true);
        textCoinGameOver.text = coins.ToString("D2");
    }

    //Show  Game Object responsible for showing Win and updating the coins
    public void Win(int coins)
    {
        WinObj.SetActive(true);
        textCoinWin.text = coins.ToString("D2");
    }

    //Show  Game Object responsible for showing Pause 
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

    //Call NextLevel in GameController
    public void NextLevel()
    {
        gameController.NextLevel();
    }

    //Exit Game
    public void ExitGame()
    {
        Application.Quit();
    }
}
