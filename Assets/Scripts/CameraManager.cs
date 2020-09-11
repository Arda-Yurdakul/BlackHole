using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{

	public Vector3[] Positions;
	private int myCurrentIndex = 0;

	public Transform camTransform;
	public static float shakeDuration = 0f;
	public float shakeAmount = 0.4f;
	public float decreaseFactor = 2.0f;

	Vector3 originalPos;
	

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		
			if (shakeDuration > 0)
			{
				camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

				shakeDuration -= Time.deltaTime * decreaseFactor;
			}
			else
			{
				shakeDuration = 0f;
				//camTransform.localPosition = originalPos;
			}
		

		if(GameManager.phaseOneDone)
        {
			myCurrentIndex = 1;
		}
		else
        {
			myCurrentIndex = 0;
        }

		transform.position = Vector3.Lerp(transform.position, Positions[myCurrentIndex], 1f * Time.deltaTime);
		

	}  

	public void ResetCamera()
    {
		camTransform.position = new Vector3(0, 6.23f, -4.38f);
    }
 
}