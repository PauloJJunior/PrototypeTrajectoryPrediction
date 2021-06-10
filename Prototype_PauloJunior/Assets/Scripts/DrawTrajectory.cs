using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class responsible for projecting the trajectory of the player on the screen.
public class DrawTrajectory : MonoBehaviour
{
    // Declare a static instance
    public static DrawTrajectory instance;

    //Variable Line Renderer
    [SerializeField]
    private LineRenderer lineRenderer;

    //Size Line Segment
    [SerializeField]
    [Range(3, 100)]
    private int lineSegmentCount = 20;

    //Percentage of the trajectory that will be displayed to the player.
    [SerializeField]
    [Range(10, 100)]
    private int showPercentage = 50;

    private int linePointCount;

    private List<Vector3> linePoints = new List<Vector3>();

    private void Awake()
    {

        // Tests if the class has already been instantiated
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;

        }

        instance = this;

        //Calculates the percentage to display the line
        linePointCount = (int)(lineSegmentCount * (showPercentage / 100f));

    }



    //Method responsible for designing the trajectory.
    public void UpdateTrajectory(Vector3 forceVector, Rigidbody  rigidbody, Vector3 staringPoint)
    {

        //Calculate the trajectory
        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;
        float FlightDuration = (2 * velocity.y) / Physics.gravity.y;
        float stepTime = FlightDuration / lineSegmentCount;


        //Clear the list
        linePoints.Clear();
        //Add startPoint in the list
        linePoints.Add(staringPoint);


        //It cycles through the number of linah points determined and adds the point to the list.
        for (int i = 1; i < linePointCount; i++)
        {
            float stepTimePassed = stepTime * i;

            Vector3 MovementVector = new Vector3(
                                            x: velocity.x * stepTimePassed,
                                            y: velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                                            z: velocity.z * stepTimePassed
                                            );



            //Test if hit a target and returns.
            RaycastHit hit;
            Vector3 NewPointOnLine = -MovementVector + staringPoint;
            if (Physics.Raycast(origin:linePoints[i-1], direction:NewPointOnLine- linePoints[i - 1], out hit, (NewPointOnLine-linePoints[i-1]).magnitude))
            {
                linePoints.Add(hit.point);
                break;
            }


            //Add point to list.
            linePoints.Add(NewPointOnLine);
        }

        //Draws the dots on the screen.
        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());


    }


    //Hide Line
    public void HideLine()
    {
        lineRenderer.positionCount = 0;
    }
}
