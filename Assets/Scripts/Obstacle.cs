using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ScoreBehavior scoreBehavior;
    public GameObject BlackHole;
    public GameManager gameManager;
    [Space]

    [Header ("Pull Variables")]
    private float pullThreshold;
    private float pullStrength;
    AudioSource audio;


    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        pullThreshold = 0.58f;
        pullStrength = 1.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.defaultSolverIterations = 20;
        Vector3 heading = transform.position - BlackHole.GetComponent<Transform>().position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        if (distance < pullThreshold && heading.y >= 0 && CompareTag("Hazard") == false && CompareTag("Hazard2") == false)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(direction * pullStrength * -1);
        }

        if (transform.position.y < -1f)
        {
            Destroy(gameObject);
            if(gameObject.CompareTag("Hazard") || gameObject.CompareTag("Hazard2"))
            {
                Handheld.Vibrate();
                GameManager.isGameover = true;
            }
                
            else
            {
                scoreBehavior.Score();
            }
        }

        
       
    }


    
}
