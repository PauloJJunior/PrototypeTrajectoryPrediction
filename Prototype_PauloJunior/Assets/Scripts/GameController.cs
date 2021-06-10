using UnityEngine;
using UnityEngine.SceneManagement;


//Class responsible for general game control.
public class GameController : MonoBehaviour
{

    //Current GameState
    public GameState CurrentGameState { get; set; }

    //Tag UIController
    [SerializeField]
    private string uiControllerTag = "UIController";

    //Tag UIController
    [SerializeField]
    private string playerTag = "Player";

    //Local  variable Coin
    private int coin;

    //Local variable Player Color
    private Color playerColor;

    // local variable PlayerController
    private PlayerController playerController;

    // local variable UIController
    private UIController uiController;

    // local variable nextScene
    private int nextSceneLoad;

    // Start is called before the first frame update
    void Start()
    {
        //Set GameState To GamePlay
        CurrentGameState = GameState.GAMEPLAY;

        // search the playerController  for the tag
        playerController = GameObject.FindGameObjectWithTag(playerTag).transform.GetComponent<PlayerController>();

        // search the uiController  for the tag
        uiController = GameObject.FindGameObjectWithTag(uiControllerTag).transform.GetComponent<UIController>();

        // set nextScene
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }


    //Coin Controller
    public int Coin {

        get { return coin; }

        set {

            coin = value;

            // Update coin in UI 
            uiController.setCoin(coin);

            // Update coin in playerData
            DataStorage.playerData.coins += value;
        }
    }


    //Color Controller
    public Color PlayerColor
    {

        get { return playerColor; }

        set
        {
          
            playerColor = value;

            // Update player in UI 
            uiController.setPlayerColor(playerColor);

        }
    }



    public void GameOver()
    {
        if (CurrentGameState != GameState.GAMEOVER){

            //Set Current GameState to GameOver
            CurrentGameState = GameState.GAMEOVER;

            //Play Clip GameOver
            SFXController.instance.PlayClip(SFXController.instance.gameOverClip);

            // Update coin in UI GameOver
            uiController.GameOver(Coin);
            
        }
       
    }


    public void Win()
    {
        if (CurrentGameState != GameState.WIN)
        {
            //Set Current GameState to Win
            CurrentGameState = GameState.WIN;

            //Play Clip Win
            SFXController.instance.PlayClip(SFXController.instance.winClip);

            // Update coin in UI Win
            uiController.Win(Coin);
            
        }
      
    }

    //Pause Game Controller
    public void Pause()
    {

        if(CurrentGameState != GameState.PAUSE)
        {
            //Set Current GameState to Pause
            CurrentGameState = GameState.PAUSE;

            //Set timescale to 0, preventing anything from moving
            Time.timeScale = 0;
        }
        else
        {
            //Set Current GameState to GamePlay
            CurrentGameState = GameState.GAMEPLAY;

            //Set timescale to 0, preventing anything from moving
            Time.timeScale = 1;
        }
       

    }


    // Controller NextLevel
    public void NextLevel()
    {

        //Tests whether the current scene is the same as the last scene defined in the playerData
        if (SceneManager.GetActiveScene().buildIndex == DataStorage.playerData.maxLevel)
        {
           
            // Show Finish Object
            uiController.FinishObj.SetActive(true);

        }
        else
        {
            //Test if the next scene is bigger than the current one
            if (nextSceneLoad > DataStorage.playerData.currentLevel)
            {
                //Save nextLevel in playerData
                DataStorage.playerData.currentLevel = nextSceneLoad;
            }

            //Load NextScene
            SceneManager.LoadScene(nextSceneLoad);
        }
    }
}
