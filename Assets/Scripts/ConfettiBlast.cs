using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiBlast : MonoBehaviour
{
    ParticleSystem confetti;
    // Start is called before the first frame update
    void Start()
    {
        confetti = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Celebration()
    {
      confetti.Play();    
    }
}
