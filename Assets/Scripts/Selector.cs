using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Selector : MonoBehaviour
{
    // private Color color;
    bool loaded;
    bool ray_on;    
    public GameObject ray;
    // Debugging
    [SerializeField] TextMeshProUGUI m_Text;


    // Start is called before the first frame update
    void Start()
    {
        // Initial select mode: hand
        loaded = false;
        ray_on = false;
        ray.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ray_on == false)
        {
            ray.SetActive(false);
        }

        // loaded = (GameObject.FindGameObjectsWithTag("ball").Length >0);
        // if (loaded)
        // {
        // If button "X" on left controller is released
        if (OVRInput.GetUp(OVRInput.Button.Three))
        {
            // Vibration
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
            // Change selection mode
            RaySwitch();
        // }
        }
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     if (loaded)
    //     {
            
    //         if (mode == "hand")
    //         {
    //             m_Text.text = collision.gameObject.tag;
    //             if (collision.gameObject.tag == "ball" || collision.gameObject.tag == "selectable")
    //             {

    //                 // Change color when hover over
    //                 // Renderer r = collision.gameObject.GetComponent<Renderer>();
    //                 // Material m = r.material;
    //                 // color = m.color;
    //                 // m.color = Color.yellow;

    //                 // Left trigger: select
    //                 if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.0f)
    //                 {
    //                     m_Text.text = "object picked";
    //                     // collision.gameObject.transform.position = transform.position;
    //                     // collision.gameObject.transform.rotation = transform.rotation;
    //                     collision.transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
    //                     collision.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
    //                 }

    //             }
    //         }
    //     }
        
    // }

    // void OnTriggerExit(Collider collision)
    // {
    //     Renderer r = collision.gameObject.GetComponent<Renderer>();
    //     Material m = r.material;
    //     m.color = color;
    // }


    // Switch between virtual hand and controller
    void RaySwitch()
    {
        ray_on = !ray_on;
        if (ray_on)
        {
            ray.SetActive(true);
        }
            // TODO: setactive the hand

    }
}

