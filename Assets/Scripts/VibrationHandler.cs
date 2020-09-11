using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationHandler : MonoBehaviour
{
    private bool vibrato;
    public GameObject vibrationText;
    public void ToggleVibration()
    {
        
        if (GameManager.soundEnabled)
        {
            GameManager.soundEnabled = false;
            vibrationText.GetComponent<Text>().text = "Sound: OFF";
        }
        else
        {
            GameManager.soundEnabled = true;
            vibrationText.GetComponent<Text>().text = "Sound: ON";
        }
            
    }
}
