using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{


    [Range(0, 50)]
    public float SpeedFanX = 0;

    [Range(0, 50)]
    public float SpeedFanY = 0;

    [Range(0, 50)]
    public float SpeedFanZ = 0;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(1 * SpeedFanX * Time.deltaTime, 1 * SpeedFanY * Time.deltaTime, 1 *  SpeedFanZ * Time.deltaTime);
      
    }
}
