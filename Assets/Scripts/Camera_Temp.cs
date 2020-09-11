using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Temp : MonoBehaviour
{
    public Vector3[] Positions;
    private int myCurrentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myCurrentIndex = 1;
            
        }

        transform.position = Vector3.Lerp(transform.position, Positions[myCurrentIndex], 2f * Time.deltaTime);
    }
}
