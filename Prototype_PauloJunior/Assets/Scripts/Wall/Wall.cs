using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class responsible for controlling the walls.
public class Wall : MonoBehaviour
{

    //Variable Current TypeWall
    public TypeWall TypeCurrentWall;


    //Variable TypeWall NextWall
    public TypeWall NextWall;

    //Contains all available wall materials in the game.
    public Material[] Materials;

    // Variable NextMaterial
    public Material NextMaterial;




    // Start is called before the first frame update
    void Start()
    {
        //Select Material Wall and NextWall in vector
        selectMaterials();
    }



    //Select Material  Wall and NextWall in vector based on the Typewall.
    void selectMaterials()
    {
        switch (TypeCurrentWall)
        {
            case TypeWall.BLUE:
                this.GetComponent<Renderer>().material = Materials[0];
                break;
            case TypeWall.RED:
                this.GetComponent<Renderer>().material = Materials[1];
                break;
            case TypeWall.YELLOW:
                this.GetComponent<Renderer>().material = Materials[2];
                break;

        }



        switch (NextWall)
        {
            case TypeWall.BLUE:
                NextMaterial = Materials[0];
                break;
            case TypeWall.RED:
                NextMaterial = Materials[1];
                break;
            case TypeWall.YELLOW:
                NextMaterial = Materials[2];
                break;

        }

    }


}
