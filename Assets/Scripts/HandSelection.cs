using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandSelection : MonoBehaviour
{
    public GameObject golfClub;
    //public GameObject golfClubHead;
    //public GameObject golfClubShaft;
    //public GameObject golfBall;

    public GameObject right_controller;

    [SerializeField] TextMeshProUGUI m_Text;

    
    // Start is called before the first frame update
    void Start()
    {
        golfClub.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // Left hand trigger: change selection modes of left hands
        // if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.0f)
        // {
        //     ChangeMode();
        // }

        // Right hand trigger: play
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.0f)
        {
            golfClub.SetActive(true); 
            // golfClub.transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
            // this.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
            golfClub.transform.position = new Vector3(right_controller.transform.position.x, right_controller.transform.position.y/2, right_controller.transform.position.z);
            golfClub.transform.rotation = right_controller.transform.rotation;
            golfClub.transform.SetParent(right_controller.transform); 
        }
        else {golfClub.SetActive(false);}


    }

    

}
