using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Rigidbody t1;
    public Rigidbody t2;
    public Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        cam.transform.position = (t1.position + t2.position);
    }
    private void Update()
    {
        float zoomFactor = 1.5f;
     float followTimeDelta = 0.8f;
 
     // Midpoint we're after
     Vector3 midpoint = (t1.position + t2.position) / 2f;
 
     // Distance between objects
     float distance = (t1.position - t2.position).magnitude;
 
     // Move camera a certain distance
     Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;
     cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);
         
     // Snap when close enough to prevent annoying slerp behavior
     if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
         cam.transform.position = cameraDestination;
    }
}
