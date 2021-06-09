using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    //Player RB
    private Rigidbody playerRb;


    //Player inWall
    private bool isWall;


    public string GameControllerTag = "GameController";

    private Vector3 inputPressDownPos;
    private Vector3 inputReleasePos;

    private float startLife;

    public float Life { get; set; }


    // Start is called before the first frame update


    public PlayerScriptable PlayerPresets;

    private GameController gameController;

    public Color ColorPlayer;

    public Renderer RenderPlayer { get; set; }

    public TypeWall NextWall = TypeWall.ALL;

   

    void Start()
    {
        //Sign RB PLAYER
        playerRb = GetComponent<Rigidbody>();

        startLife = PlayerPresets.Life;
        Life = PlayerPresets.Life;

        gameController = GameObject.FindGameObjectWithTag(GameControllerTag).transform.GetComponent<GameController>();

        StartCoroutine("LifeTimeController");

        RenderPlayer = this.gameObject.transform.GetChild(0).GetComponent<Renderer>();

        ColorPlayer = RenderPlayer.material.color;

     

        this.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().material = null;

    }

    // Update is called once per frame
    void Update()
    {


        
        CheckGameOver();
    }


    void CheckGameOver()
    {

        if(Life <= 0)
        {
            gameController.GameOver();
            return;
        }

        if (transform.position.y < -5f)
        {
            gameController.GameOver();
            return;
        }

    }

    private void OnMouseDrag()
    {
        if (Input.mousePosition.y < inputPressDownPos.y)
        {
            Vector3 forceInit = (Input.mousePosition - inputPressDownPos);
            Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, z: forceInit.y)) * PlayerPresets.ForceMultiplier;


            if (!isWall) return;

            DrawTrajectory.instance.UpdateTrajectory(forceV, playerRb, staringPoint: transform.position);
        }
        else DrawTrajectory.instance.HideLine();



    }
    private void OnMouseDown()
    {
        inputPressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        
        inputReleasePos = Input.mousePosition;

        if (inputReleasePos.y < inputPressDownPos.y)
        {
            ShootPlayer(inputPressDownPos - inputReleasePos);
        }
    }




    void ShootPlayer(Vector3 force)
    {
      
        if (!isWall) return;

        DrawTrajectory.instance.HideLine();
        playerRb.drag = 0;
        playerRb.AddForce(new Vector3(force.x, force.y, force.y) * PlayerPresets.ForceMultiplier);
       
    }

    IEnumerator LifeTimeController()
    {

        yield return new WaitForSeconds(PlayerPresets.LifeSeconds);
        if (gameController.CurrentGameState == GameState.GAMEPLAY)
        {
            Life--;
            ColorPlayer.a = Life / startLife;
            RenderPlayer.material.color = ColorPlayer;
            gameController.PlayerColor = ColorPlayer;
        }
   
        StartCoroutine("LifeTimeController");
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Wall")
        {
            Wall wall = collision.gameObject.GetComponent<Wall>();


            if (NextWall == wall.TypeCurrentWall || NextWall == TypeWall.ALL)
            {
                NextWall = wall.NextWall;
                isWall = true;
                playerRb.drag = PlayerPresets.Drag;

                ColorPlayer.r = wall.NextMaterial.color.r;
                ColorPlayer.g = wall.NextMaterial.color.g;
                ColorPlayer.b = wall.NextMaterial.color.b;
                RenderPlayer.material.color = ColorPlayer;
                RenderPlayer.material.SetColor("_EmissionColor", wall.NextMaterial.GetColor("_EmissionColor"));
                RenderPlayer.material.SetColor("_EmissionColor", wall.NextMaterial.GetColor("_EmissionColor"));

            }


        }
        else if (collision.gameObject.tag == "Start")
        {

            isWall = true;
            playerRb.drag = PlayerPresets.Drag;


        } else if (collision.gameObject.tag == "Finish")
        {
            if (playerRb.velocity.y == 0)
            {
                gameController.CurrentGameState = GameState.WIN;
            }

        }


    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isWall = false;
            playerRb.drag = 0;
        }
        else if (collision.gameObject.tag == "Wall")
        {
            isWall = false;
            playerRb.drag = 0;
        }
      
    }


    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Collectable")
        {
            CollectablesScriptable coll = other.GetComponent<Collectable>().Collected();

            if(coll.Type == TypeCollectable.LIFE)
            {
                print("Coletou VIDA");               
                Life += coll.LifeRestoure;
                ColorPlayer.a = Life / startLife;
                RenderPlayer.material.color = ColorPlayer;
            }
            else if (coll.Type == TypeCollectable.COIN)
            {
                print("Coletou COIN");
                gameController.Coin += coll.Coins;
            }
        }
        
    }

}
