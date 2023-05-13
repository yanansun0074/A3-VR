using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRBoundary;
using TMPro;
using UnityEngine.UI;

public class GolfBall : MonoBehaviour
{

    private GameObject hole;
    public int scores;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI WinText;
    [SerializeField] TextMeshProUGUI m_Text;
    // [SerializeField] TextMeshProUGUI m_Text2;

    public Button exit;

    bool guide_finished;

    public AudioSource audio;
    
    

    // Start is called before the first frame update
    void Start()
    {
        hole = GameObject.FindGameObjectsWithTag("hole")[0];
        scores = 0;
        guide_finished = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (guide_finished)
        {
            scoreText.text = scores.ToString();
            // m_Text2.text = this.gameObject.transform.position.ToString();
        }

        
        
    }
    void OnCollisionEnter(Collision other)
    {   // if ball is hit by golf club
        if (other.gameObject.tag == "golf club")
        {
            // increase player's scores
            scores++;
            // Pass velocity of the golf to the ball
            GetComponent<Rigidbody>().velocity = other.gameObject.GetComponent<GolfClubHead>().getVelocity() * 1.0F;
        }
        
        if (other.gameObject.tag == "hole")
        {
            // Win
            // The ball stops
            this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, -1, gameObject.transform.position.z);
            audio.Play();
            Winning();



        }
    }

    void Winning()
    {
        WinText.text = "You win! Your final scores are:";
        exit.gameObject.SetActive(true);
        
        // TODO: Add audio indicator
    }

    public void SetTrue()
    {
        guide_finished = true;
    }
}
