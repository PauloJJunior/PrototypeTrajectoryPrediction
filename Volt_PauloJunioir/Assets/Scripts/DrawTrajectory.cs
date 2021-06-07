using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{

    public static DrawTrajectory instance;

    [SerializeField]
    private LineRenderer lineRenderer;


    [SerializeField]
    [Range(3, 100)]
    private int lineSegmentCount = 20;

    [SerializeField]
    [Range(10, 100)]
    private int showPercentage = 50;
    private int linePointCount;

    private List<Vector3> linePoints = new List<Vector3>();

    private void Awake()
    {
       
        instance = this;
        linePointCount = (int)(lineSegmentCount * (showPercentage / 100f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateTrajectory(Vector3 forceVector, Rigidbody  rigidbody, Vector3 staringPoint)
    {

        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;

        float FlightDuration = (2 * velocity.y) / Physics.gravity.y;

       

        float stepTime = FlightDuration / lineSegmentCount;

        linePoints.Clear();
        linePoints.Add(staringPoint);

            //for (int i = 1; i < lineSegmentCount; i++)
            for (int i = 1; i < linePointCount; i++)
        {
            float stepTimePassed = stepTime * i;

            Vector3 MovementVector = new Vector3(
                                            x: velocity.x * stepTimePassed,
                                            y: velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                                            z: velocity.z * stepTimePassed
                                            );

           

            RaycastHit hit;
            Vector3 NewPointOnLine = -MovementVector + staringPoint;
            if (Physics.Raycast(origin:linePoints[i-1], direction:NewPointOnLine- linePoints[i - 1], out hit, (NewPointOnLine-linePoints[i-1]).magnitude))
            {
                linePoints.Add(hit.point);
                break;
            }

            Debug.DrawLine(start: linePoints[i - 1], end: NewPointOnLine, Color.magenta, duration: 0.0f, depthTest: true);
          
            linePoints.Add(NewPointOnLine);
        }

         
        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());


    }

    public void HideLine()
    {
        lineRenderer.positionCount = 0;
    }
}
