using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public TypeWall TypeCurrentWall;

    public TypeWall NextWall;

    public Material[] Materials;

    public Material NextMaterial;




    // Start is called before the first frame update
    void Start()
    {
        selectMaterials();
    }




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

    // Update is called once per frame
    void Update()
    {
        
    }
}
