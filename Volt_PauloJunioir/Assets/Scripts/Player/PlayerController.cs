using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class responsible for loading and controlling all player actions.
public class PlayerController : MonoBehaviour
{


    //Player RB
    private Rigidbody playerRb;


    //Player inWall
    private bool isWall;

    //Tag GameController
    public string GameControllerTag = "GameController";

    // Position to input press Down
    private Vector3 inputPressDownPos;

    // Position to Release
    private Vector3 inputReleasePos;

    //Start Life Player
    private float startLife;

    // Current Life Player
    public float Life { get; set; }




    //Variable a PlayerScriptable class
    public PlayerScriptable PlayerPresets;

    //Variable gameController
    private GameController gameController;

    //Variable Color Player
    public Color ColorPlayer;

    //Renderer Player
    public Renderer RenderPlayer { get; set; }

    // NextWall player need to arrive
    public TypeWall NextWall = TypeWall.ALL;


    // Position to die.
    public float PositionDie = -5f;

    // Effect to jump
    private ParticleSystem jumpEffects;

    // Effect to jump renderer
    private ParticleSystemRenderer jumpEffectsRenderer;

    // Test bool to Die
    private bool noLife;
    
    // Start Player Color
    private Color startCenterMaterial;

    //Variable for TouchController
    private bool dragging;

    //Variable for TouchController
    private bool touched;

    void Start()
    {
        //Sign RB PLAYER
        playerRb = GetComponent<Rigidbody>();

        //Sign start Life to PlayerPresets
        startLife = PlayerPresets.Life;

        //Start Current Life
        Life = startLife;

        // search the gameController  for the tag
        gameController = GameObject.FindGameObjectWithTag(GameControllerTag).transform.GetComponent<GameController>();

        // Start Coroutine count life
        StartCoroutine("LifeTimeController");

        // Sign renderPlayer in child
        RenderPlayer = this.gameObject.transform.GetChild(0).GetComponent<Renderer>();

        //Set ColorPlayer 
        ColorPlayer = RenderPlayer.material.color;


        // Set material Player Null
        this.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().material = null;

        //Instantiates and controls jump effects
        GameObject effect = Instantiate(PlayerPresets.JumpEffect, this.transform.position, Quaternion.identity);
        effect.transform.parent = this.gameObject.transform;
        jumpEffects = effect.GetComponent<ParticleSystem>();
        jumpEffectsRenderer = effect.GetComponent<ParticleSystemRenderer>();
        jumpEffects.Stop();
        jumpEffectsRenderer.material.color = ColorPlayer;

        // Set startCenterMaterial
        startCenterMaterial = this.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.color;

        //Hide Line trajectory
        DrawTrajectory.instance.HideLine();
    }

    // Update is called once per frame
    void Update()
    {
        // TouchController
        TouchController();

        // Tests whether he died by positioning
        CheckGameOver();

        // Tests whether he Life
        CheckLife();
    }

    void CheckLife()
    {
        //Tests current life and alters center material.
        if (Life <= 0)
        {

            if (!noLife)
            {
                noLife = true;
                this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = PlayerPresets.noLifeCenterMaterial;
            }

        }
        else
        {
            if (noLife)
            {
                noLife = false;
                this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = startCenterMaterial;
            }
        }

    }

    // Tests whether he died by positioning and Life.
    void CheckGameOver()
    {

        //Tests current position and alters GameState to GameOver.
        if (transform.position.y < PositionDie)
        {
            gameController.GameOver();
            return;
        }

    }


    void TouchController()
    {
        //Test Plataform
        if (Application.platform != RuntimePlatform.Android)
            return;


            if (Input.touchCount != 1)
        {
            touched = false;
            dragging = false;
            return;
        }

        Touch touch = Input.touches[0];

        if(touch.phase == TouchPhase.Began)
        {
            ActionInputDown(Input.GetTouch(0).position);
            touched = true;
        }


        if (touched && touch.phase == TouchPhase.Moved)
        {
            dragging = true;
            ActionInputDrag(Input.GetTouch(0).position);
          
        }


        if (dragging &&  (touch.phase == TouchPhase.Ended || touch.phase ==  TouchPhase.Canceled))
        {
            touched = false;
            dragging = false;
            ActionInputUp();

        }

    }

   
    private void OnMouseDrag()
    {
             
        ActionInputDrag(Input.mousePosition);

    }
    private void OnMouseDown()
    {
       ActionInputDown(Input.mousePosition);
       
    }

    private void OnMouseUp()
    {
       ActionInputUp();
    }


    void ActionInputDown(Vector3 inputPositionDown)
    {

        // Test GameState and save PressDown Position
        if (gameController.CurrentGameState == GameState.GAMEPLAY)
            inputPressDownPos = inputPositionDown;

    }
    void ActionInputUp()
    {

        //Stop Jump Clip
        SFXController.instance.PlayClipLoop(PlayerPresets.DragClip, true);

        //Stop Effect
        jumpEffects.Stop();

        //Save ReleasePos
        inputReleasePos = Input.mousePosition;

        // Test position is Ok and GameState
        if (inputReleasePos.y < inputPressDownPos.y && gameController.CurrentGameState == GameState.GAMEPLAY)
        {
            // Call ShootPlayer
            ShootPlayer(inputPressDownPos - inputReleasePos);
        }

    }


    void ActionInputDrag(Vector3 inputPositionDrag)
    {
        if (inputPositionDrag.y < inputPressDownPos.y && gameController.CurrentGameState == GameState.GAMEPLAY)
        {

            //Calculates the current position and the position at which the touch was pressed.
            Vector3 forceInit = (inputPositionDrag - inputPressDownPos);
            Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, z: forceInit.y)) * PlayerPresets.ForceMultiplier;

            //Test if Player in wall
            if (!isWall) return;

            //DrawTrajectory
            DrawTrajectory.instance.UpdateTrajectory(forceV, playerRb, staringPoint: transform.position);

            //Controll Jump Effects
            jumpEffectsRenderer.material.color = ColorPlayer;
            jumpEffects.Play();

            //Player Clip Loop
            SFXController.instance.PlayClipLoop(PlayerPresets.DragClip, false);
        }
        // Hide Line trajectory
        else DrawTrajectory.instance.HideLine();

    }
    // Add Force to player.
    void ShootPlayer(Vector3 force)
    {
      
        //Test if is Wall
        if (!isWall) return;

        //Play Clip Jump
        SFXController.instance.PlayClip(PlayerPresets.JumpClip);

        //Hide Line Trajectory
        DrawTrajectory.instance.HideLine();

        // Set Player Drag to 0
        playerRb.drag = 0;

        // AddForce to Player
        playerRb.AddForce(new Vector3(force.x, force.y, force.y) * PlayerPresets.ForceMultiplier);
       
    }

    //Corrotine Life Controller
    IEnumerator LifeTimeController()
    {

        //Wait for seconds to playerPressets  define
        yield return new WaitForSeconds(PlayerPresets.LifeSeconds);

        //Test GameState
        if (gameController.CurrentGameState == GameState.GAMEPLAY)
        {
            //Set Current Life
            Life--;

            // Set Alpha current Alpha based on life
            ColorPlayer.a = Life / startLife;
            RenderPlayer.material.color = ColorPlayer;

            //Set in gameControlelr PlayerColor
            gameController.PlayerColor = ColorPlayer;
        }
   
        //Start Coroutine again
        StartCoroutine("LifeTimeController");
    }

    private void OnCollisionEnter(Collision collision)
    {

        //Test Collision Tag is Wall
        if (collision.gameObject.tag == "Wall")
        {

            
            Wall wall = collision.gameObject.GetComponent<Wall>();

            //Test if CurrentNextWall is right.
            if (NextWall == wall.TypeCurrentWall || NextWall == TypeWall.ALL)
            {
                if (!noLife)
                {
                    NextWall = wall.NextWall;
                    isWall = true;

                    // Set Player Drag on PlayerPresets
                    playerRb.drag = PlayerPresets.Drag;

                    //Change PlayerColor and Emission to nextWall Color
                    ColorPlayer.r = wall.NextMaterial.color.r;
                    ColorPlayer.g = wall.NextMaterial.color.g;
                    ColorPlayer.b = wall.NextMaterial.color.b;
                    RenderPlayer.material.color = ColorPlayer;
                    RenderPlayer.material.SetColor("_EmissionColor", wall.NextMaterial.GetColor("_EmissionColor"));
                    RenderPlayer.material.SetColor("_EmissionColor", wall.NextMaterial.GetColor("_EmissionColor"));
                }
             

            }
            else
            {
                //Clip sound fail
                SFXController.instance.PlayClip(PlayerPresets.HitClip);
            }


        }
        //Test Collision Tag is Start
        else if (collision.gameObject.tag == "Start")
        {

            isWall = true;
            // Set Player Drag on PlayerPresets
            playerRb.drag = PlayerPresets.Drag;


        }  
        //Test Collision Tag is Start
        else if (collision.gameObject.tag == "Finish")
        {

            // Set Win in gameController
            gameController.Win();
          

        }
        //Test Collision Tag is Trampoline
        else if (collision.gameObject.tag == "Trampoline")
        {
            //Player Clip to Trampoline
            SFXController.instance.PlayClip(PlayerPresets.HitClip);
        }


    }


    private void OnCollisionExit(Collision collision)
    {

        //Test Collision Tag is Start
        if (collision.gameObject.tag == "Wall")
        {
            isWall = false;

            // Set Player Drag for jump
            playerRb.drag = 0;
        }
        else if (collision.gameObject.tag == "Start")
        {
            isWall = false;

            // Set Player Drag for jump
            playerRb.drag = 0;
        }




    }


    private void OnTriggerEnter(Collider other)
    {

        //Test Collision Tag is Collectable
        if (other.tag == "Collectable")
        {
            CollectablesScriptable coll = other.GetComponent<Collectable>().Collected();


            //Test type of Collectable
            if(coll.Type == TypeCollectable.LIFE)
            {

                //Update the player's life and color.
                Life += coll.LifeRestoure;
                ColorPlayer.a = Life / startLife;
                RenderPlayer.material.color = ColorPlayer;

                //Player Clip to Collectable
                SFXController.instance.PlayClip(coll.CollectClip);
            }
            //Test Collision Tag is COIN
            else if (coll.Type == TypeCollectable.COIN)
            {
                //Update the player's coin.
                gameController.Coin += coll.Coins;

                //Player Clip to Collectable
                SFXController.instance.PlayClip(coll.CollectClip);
            }
        }
        
    }

}
