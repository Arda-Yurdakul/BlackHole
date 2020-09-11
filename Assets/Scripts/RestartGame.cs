using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    
    public void ResetEverything()
    {
        GameManager.isGameover = false;
        GameManager.isMoving = false;
        GameManager.phaseOneDone = false;
        GameManager.phaseTwoDone = false;
        GameManager.currentScore = 0;
        GameManager.currentLevel = 1;
        SceneManager.LoadScene(0);
    }
}
