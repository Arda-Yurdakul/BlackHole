using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehavior2 : MonoBehaviour
{
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.minValue = 0;
        slider.maxValue = GameManager.scoreGoal2[GameManager.currentLevel - 1];
        if (GameManager.phaseOneDone == true && GameManager.phaseTwoDone == false)
        {
            slider.value = GameManager.currentScore;
        }
       if (GameManager.phaseOneDone == false && GameManager.phaseTwoDone == false)
        {
            slider.value = 0;
        }
    }
}
