using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float SmoothSpeed = 1f;

    public Vector3 Offset;

    private Vector3 startOffset;

    public string TagPlayer = "Player";

    private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(TagPlayer).transform;
        startOffset = Offset;
    }

    private void LateUpdate()
    {
        if (target.position.x > 0) Offset.x = -1.5f;
        else if (target.position.x < 0) Offset.x = +1.5f;
        else Offset = startOffset;

        Vector3 desiredPosition = target.position + Offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
