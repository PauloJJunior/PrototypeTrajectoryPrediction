using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    //Player RB
    private Rigidbody playerRb;


    //Bol inWall
    private bool inWall;

    // Start is called before the first frame update

    void Start()
    {
        //Sign RB PLAYER
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Wall")
        {
            inWall = true;
            playerRb.drag = 30;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            inWall = false;
            playerRb.drag = 0;
        }
    }

}
