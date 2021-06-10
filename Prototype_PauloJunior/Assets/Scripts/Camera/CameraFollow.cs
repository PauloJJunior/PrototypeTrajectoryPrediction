using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script is intended to follow the game by adjusting the position of the camera.
public class CameraFollow : MonoBehaviour
{

    // SmoothSpeed move
    public float SmoothSpeed = 1f;

    // Offset set ins inspector
    public Vector3 Offset;

    //Save startOffset
    private Vector3 startOffset;

    //Tag to search the player object
    public string TagPlayer = "Player";

    //Tag to search the finish object
    public string TagFinish = "Finish";

    //Tag to search the GameController object
    public string GameControllerTag = "GameController";

    //Local gameController
    private GameController gameController;

    // Transform target to follow
    private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        // search the player  for the tag
        target = GameObject.FindGameObjectWithTag(TagPlayer).transform;

        // search the finish  for the tag
        this.transform.position = GameObject.FindGameObjectWithTag(TagFinish).transform.position;

        // search the gameController  for the tag
        gameController = GameObject.FindGameObjectWithTag(GameControllerTag).transform.GetComponent<GameController>();

        //Save start Offset
        startOffset = Offset;
    }

    private void LateUpdate()
    {
        // Test if GameState is not GameOver
        if(gameController.CurrentGameState != GameState.GAMEOVER)
        {
            // Determines position according to which side of the screen the player is on.
            if (target.position.x > 0) Offset.x = -1.5f;
            else if (target.position.x < 0) Offset.x = +1.5f;
            else Offset = startOffset;

            //Follow the target
            Vector3 desiredPosition = target.position + Offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    
    }
}
