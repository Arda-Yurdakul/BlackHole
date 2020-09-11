using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehavior : MonoBehaviour
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
        slider.maxValue = GameManager.scoreGoal1[GameManager.currentLevel - 1];
        print(GameManager.currentLevel);
        if(GameManager.phaseOneDone == false)
        {
            slider.value = GameManager.currentScore;
        }
    }
}
