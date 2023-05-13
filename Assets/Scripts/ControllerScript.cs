using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    public GameObject golfClub;
    private float step;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = sceneCamera.transform.position + sceneCamera.transform.forward * 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        step = 5.0f * Time.deltaTime;
        // Right hand trigger & thumbstick
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.0f) centerCube();
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft)) transform.Rotate(0, 5.0f * step, 0);
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight)) transform.Rotate(0, -5.0f * step, 0);
        // Left hand trigger
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.0f)
        {   // Left hand trigger position & rotation
            transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
            transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
        }
    }
    
    void centerCube()
    {
        targetPosition = sceneCamera.transform.position + sceneCamera.transform.forward * 3.0f;
        targetRotation = Quaternion.LookRotation(transform.position - sceneCamera.transform.position);

        transform.position = Vector3.Lerp(transform.position, targetPosition, step);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step);
    }
}
