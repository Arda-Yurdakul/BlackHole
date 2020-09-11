using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button settingsButton;
    public CameraManager cameraManager;
    public ParticleSystem confetti;
    public GameObject playerPrompt;
    public GameObject lvl1Assets;
    public GameObject lvl2Assets;
    public GameObject lvl3Assets;
    public static int[] scoreGoal1 = {140, 16, 18};
    public static int[] scoreGoal2 = { 6, 17, 497 };


    public static bool isGameover = false;
    public static bool isMoving = false;
    public static bool phaseOneDone = false;
    public static bool phaseTwoDone = false;
    public static bool shakeTime = false;
    public static bool soundEnabled = true;
    public static int currentScore;
    public static bool confettiTime = false;
    public static int currentLevel = 1;

    AudioSource audioSource;
   
    private Vector3 SecondCameraPosition;
    private float cameraSpeed;
    
    // Start is called before the first frame update
   
    void Start()
    {
        currentScore = 0;
        cameraSpeed = 0.1f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameover)
        {
            phaseOneDone = false;
            phaseTwoDone = false;
            isGameover = false;
            currentScore = 0;
            CameraManager.shakeDuration = 0.5f;
            Scene scene = SceneManager.GetActiveScene();
            //currentLevel = 1;
            //SceneManager.LoadScene(scene.name);
            if (currentLevel == 1)
                SceneManager.LoadScene(scene.name);
            else if(currentLevel == 2)
            {
                Destroy(GameObject.Find("lvl2Assets(Clone)").gameObject);
                Instantiate(lvl2Assets);
            }
            else if (currentLevel == 3)
            {
                Destroy(GameObject.Find("level3Assets(Clone)").gameObject);
                Instantiate(lvl3Assets);
            }

        }

        if (currentScore == scoreGoal1[currentLevel - 1] && phaseOneDone == false)  
        {
            currentScore = 0;
            phaseOneDone = true;
            print("Victory!");
            //holeMovement.transform.position = holeMovement.transform.position + new Vector3(0, 0, 10);
            
        }

        if (currentScore == scoreGoal2[currentLevel - 1] && phaseOneDone == true)
        {
            phaseTwoDone = true;
            confetti.Play();
            currentScore = 0;
            print("Eternal Glory!");
            StartCoroutine(LoadNextLevel());
            if (currentLevel == 1)
                StartCoroutine(LoadLevel2());
            else if (currentLevel == 2)
                StartCoroutine(LoadLevel3());
            else if (currentLevel == 3)
                StartCoroutine(LoadLevel4());

        }

        if (isMoving)
        {
            playerPrompt.SetActive(false);
        }


        print(currentLevel);
       
    }

    public void Score()
    {
        currentScore++;
        if (soundEnabled)
            audioSource.Play();

    }

    IEnumerator LoadNextLevel()
    {
        
        yield return new WaitForSeconds(1.0F);
        phaseOneDone = false;
        phaseTwoDone = false;
        playerPrompt.SetActive(true);
        cameraManager.ResetCamera();
        

    }
    IEnumerator LoadLevel2()
    {
        yield return new WaitForSeconds(1.0F);
        currentLevel = 2;
        Destroy(lvl1Assets);
        Instantiate(lvl2Assets);
    }
    IEnumerator LoadLevel3()
    {
        yield return new WaitForSeconds(1.0F);
        currentLevel = 3;
        //GameObject go = GameObject.Find("lvl2Assets(Clone)");
        Destroy(GameObject.Find("lvl2Assets(Clone)").gameObject);
        Instantiate(lvl3Assets);
    }

    IEnumerator LoadLevel4()
    {
        yield return new WaitForSeconds(1.0F);
        SceneManager.LoadScene("Celebration");
    }
}
