using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    //Player RB
    private Rigidbody playerRb;


    //Ball inWall
    private bool isWall;

    //Ball in Shot
    private bool isShot;


    private Vector3 inputPressDownPos;
    private Vector3 inputReleasePos;
    private float forceMultiplier = 0.3f;
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

    private void OnMouseDrag()
    {
        Vector3 forceInit = (Input.mousePosition-inputPressDownPos);
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, z:forceInit.y)) * forceMultiplier;

        //if (isShot) return;
       // if (!isWall) return;

        DrawTrajectory.instance.UpdateTrajectory(forceVector:forceV, playerRb, staringPoint: transform.position);

    }
    private void OnMouseDown()
    {
        inputPressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        
        inputReleasePos = Input.mousePosition;
        ShootPlayer(force: inputReleasePos - inputPressDownPos);
        
    }




    void ShootPlayer(Vector3 force)
    {
        if (isShot) return;
        if (!isWall) return;

        //DrawTrajectory.instance.HideLine();
        playerRb.AddForce(new Vector3(force.x, force.y, force.y) * forceMultiplier);
       // isShot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Wall")
        {
            isWall = true;
            playerRb.drag = 0;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isWall = false;
            playerRb.drag = 0;
        }
    }

}
