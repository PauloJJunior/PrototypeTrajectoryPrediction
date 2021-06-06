using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateTrajectory(Vector3 forceVector, Rigidbody  rigidbody, Vector3 staringPoint)
    {

        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;

        float FlightDuration = (2 * velocity.y) / Physics.gravity.y;

        float stepTime = FlightDuration / _lineSegmentCount;

        _lineSegmentCount Clear();


            for(int i = 0; 1 _linePoint)
        {
            float stepTimePassed = stepTime * i;

            Vector3 MovementVector = new Vector3(
                                            x: velocity.x * stepTimePassed,
                                            y: velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTime * stepTimePassed,
                                            z: velocity.z * stepTimePassed
                                            );

            RaycastHit hit;

            if(Physics.Raycast(origin:staringPoint, direction:-MovementVector, out hit, MovementVector.magnitude))
            {
                break;
            }

            _linePoints.Add(item: -MovementVector + staringPoint);
        }


        _lineRenderer.positionCount = _linePoints.Count;
        _lineRenderer.SetPositions(_linePoints.ToArry());


    }
}
