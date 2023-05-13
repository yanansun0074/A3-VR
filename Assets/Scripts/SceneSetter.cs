using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SceneSetter : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    
    public GameObject ref_plane;
    private bool hitted;
    public GameObject ref_obj;

    public TextAsset sceneData;

    public GameObject rock;
    public GameObject ball;
    public GameObject hole;
    public GameObject wall;
    public GameObject horse;
    public GameObject tree;

    private Vector3 ref_pos;

    public GameObject va;
    public GameObject start_panel;
    public GameObject welcome;



    private bool triggered = false;
    

    [SerializeField] TextMeshProUGUI m_Text;
    [SerializeField] TextMeshProUGUI m_Text2;

    private bool loaded;
    private bool loaded2;

    public Button start_button;

    public Button restart;

    private Vector3 ball_pos;

    // public GameObject ball;

    // To attach to the ref_obj
    // Start is called before the first frame update
    void Start()
    {
        hitted = true;
        ref_pos = ref_plane.transform.position;
        welcome.gameObject.SetActive(true);
        // va.gameObject.transform.position = sceneCamera.transform.position + sceneCamera.transform.forward * 3.0f;
        ball.SetActive(false);
        loaded = false;
        loaded2 = false;
        restart.onClick.AddListener(Restart);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Attach reference object to left hand trigger; 
        
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.0f && hitted)
        {   // Left hand trigger position & rotation
            this.transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
            this.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
            triggered = true;
            
        }
        if (triggered == true && hitted == true)
        {
            m_Text.text = "Well done! Now you have your map in hand.";
            m_Text2.text = "The session will begin when you align your map with the target on the ground.";
        }

        // m_Text.text = loaded.ToString();
        if (loaded == true && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.0f)
        {
            m_Text.text = "Nice job! You can also pull the trigger on your left controller to grab the ball.";
            m_Text2.text = "If the ball is too faraway, use pointer! Press the 'X' button on your left controller to activate pointer.";
            loaded2 = true;
            loaded = false;

        }

        if (loaded2 == true && OVRInput.GetUp(OVRInput.Button.Three))
        {
            m_Text.text = "Great. You can also press that again to turn it off.";
            m_Text2.text = "Now you've known everything you need. Time to play. Have fun!";
            start_button.gameObject.SetActive(true);

            // ball.GetComponent<GolfBall>().guide_finished = true;
            loaded2 = false;

        }



    }

    // If ref_obj collides with ref_plane
    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "ref")
        {

                hitted = false;
                readFile();

                m_Text.text = "Congrats! Course loaded successfully.";
                m_Text2.text = "Pull the trigger of your right controller to get the club.";
                
                loaded = true;
                ref_obj.transform.position = ref_pos;
                ref_obj.transform.rotation = ref_plane.transform.rotation;

                ref_plane.SetActive(false);

                
            
        }
    }

    void readFile()
    {
        if (hitted == false)
        {

            string sceneText = sceneData.ToString();
            string[] lines = sceneText.Split("\n"[0]);
            char[] delimiterChars = {':', '(', ',', ')'};
            
            for(int k = 1; k<lines.Length; k++)
            {
                if (lines[k] == null || lines[k] == "")
                { break;}
                string[] words = lines[k].Split(delimiterChars);
                
                string obj = words[0];
                Debug.Log(obj);
                Vector3 pos = new Vector3(ref_pos.x - float.Parse(words[2])* 15, ref_pos.y - float.Parse(words[3]), ref_pos.z - float.Parse(words[4])*15 );
                Vector3 ori = Quaternion.Euler(0,float.Parse(words[5]),0) * ref_plane.transform.forward;
                

                if (obj == "rock")
                {
                    Instantiate(rock, pos, Quaternion.Euler(ori.x, ori.y, ori.z));
                }
                if (obj == "ball")
                {
                    ball.transform.position = pos;
                    ball_pos = pos;
                    ball.SetActive(true);
                }
                if (obj == "tree")
                {
                    Instantiate(tree, pos, Quaternion.Euler(ori.x, ori.y, ori.z));
                }
                if (obj == "wall")
                {
                    Instantiate(wall, pos, Quaternion.Euler(ori.x, ori.y, ori.z));
                }
                if (obj == "horse")
                {
                    Instantiate(horse, pos, Quaternion.Euler(ori.x, ori.y, ori.z));
                }
                if (obj == "hole")
                {
                    Instantiate(hole, pos, Quaternion.Euler(ori.x, ori.y, ori.z));
                }

            }
        }
    
    }

    void Restart()
    {
        
        
        ball.transform.position = ball_pos;

        ball.GetComponent<GolfBall>().scores = 0;
    }
}
