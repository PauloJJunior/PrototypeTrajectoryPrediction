using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameState CurrentGameState { get; set; }

    public float CurrentTime { get; set; }


    public int Coin { get; set; }

    private PlayerController playerController { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        CurrentGameState = GameState.GAMEPLAY;

        playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentGameState == GameState.WAIT)


            CurrentTime += Time.deltaTime;

            
    }


    public void GameOver()
    {
        CurrentGameState = GameState.GAMEOVER;
        print("Game Over");
    }
}
