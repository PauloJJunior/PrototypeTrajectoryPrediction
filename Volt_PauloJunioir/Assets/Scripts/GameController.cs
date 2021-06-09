using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        CurrentGameState = GameState.GAMEPLAY;

        playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();

        uiController = GameObject.FindGameObjectWithTag(UiControllerTag).transform.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentGameState == GameState.WAIT)


            CurrentTime += Time.deltaTime;

        print(CurrentGameState.ToString());
    }

    public int Coin {

        get { return coin; }

        set {

            coin = value;
            uiController.setCoin(coin);
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
        CurrentGameState = GameState.GAMEOVER;
        

    }
}
