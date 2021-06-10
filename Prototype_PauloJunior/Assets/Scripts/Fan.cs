using UnityEngine;

//Class responsible for controlling the FAN obstacle
public class Fan : MonoBehaviour
{

    //Speed Fan in X
    [Range(0, 50)]
    public float SpeedFanX = 0;

    //Speed Fan in Y
    [Range(0, 50)]
    public float SpeedFanY = 0;

    //Speed Fan in Z
    [Range(0, 50)]
    public float SpeedFanZ = 0;

    // Update is called once per frame
    void Update()
    {
        // Rotate Fan based in speedfan X Y Z
        transform.Rotate(1 * SpeedFanX * Time.deltaTime, 1 * SpeedFanY * Time.deltaTime, 1 *  SpeedFanZ * Time.deltaTime);
      
    }
}
