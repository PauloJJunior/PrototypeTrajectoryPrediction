using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameState CurrentGameState { get; set; }

    public float CurrentTime { get; set; }

    [SerializeField]
    private string UiControllerTag = "UIController";

    private int coin;

    private Color playerColor;

    private PlayerController playerController { get; set; }

    private UIController uiController;

    private int nextSceneLoad;

    // Start is called before the first frame update
    void Start()
    {
        CurrentGameState = GameState.GAMEPLAY;

        playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();

        uiController = GameObject.FindGameObjectWithTag(UiControllerTag).transform.GetComponent<UIController>();


        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Coin {

        get { return coin; }

        set {

            coin = value;
            uiController.setCoin(coin);
            DataStorage.playerData.coins += value;
        }
    }


    public Color PlayerColor
    {

        get { return playerColor; }

        set
        {
          
            playerColor = value;
            uiController.setPlayerColor(playerColor);

        }
    }



    public void GameOver()
    {
        if (CurrentGameState != GameState.GAMEOVER){
            CurrentGameState = GameState.GAMEOVER;
            SFXController.instance.PlayClip(SFXController.instance.gameOverClip);
            uiController.GameOver(Coin);
            
        }
       



    }


    public void Win()
    {
        if (CurrentGameState != GameState.WIN)
        {
            CurrentGameState = GameState.WIN;
            SFXController.instance.PlayClip(SFXController.instance.winClip);
            uiController.Win(Coin);
            
        }
      
    }


    public void Pause()
    {
        if(CurrentGameState != GameState.PAUSE)
        {
            CurrentGameState = GameState.PAUSE;
            //Set timescale to 0, preventing anything from moving
            Time.timeScale = 0;
        }
        else
        {
            CurrentGameState = GameState.GAMEPLAY;
            //Set timescale to 0, preventing anything from moving
            Time.timeScale = 1;
        }
       

    }

    public void NextLevel()
    {
      
        if (SceneManager.GetActiveScene().buildIndex == DataStorage.playerData.maxLevel)
        {
            Debug.Log("FinishGame");

            uiController.FinishObj.SetActive(true);

        }
        else
        {

            if (nextSceneLoad > DataStorage.playerData.currentLevel)
            {
                DataStorage.playerData.currentLevel = nextSceneLoad;
            }

            SceneManager.LoadScene(nextSceneLoad);
        }
    }
}
