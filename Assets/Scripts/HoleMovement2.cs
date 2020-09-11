using UnityEngine;
using System.Collections.Generic;

public class HoleMovement2 : MonoBehaviour
{
	public GameManager gameManager;
	[Header("Hole mesh")]
	public MeshFilter meshFilter;
	public MeshCollider meshCollider;


	[Header("Hole effective radius")]
	public float radius;
	public Transform HoleCenter;
	public Vector2 movementLimits;

	[Space]
	public float moveSpeed;


	Mesh mesh;
	List<int> holeVertices;
	List<Vector3> offsets;
	int holeVerticesCount;

	float x, y;
	Vector3 touch, targetPos;


	void Start()
	{
		GameManager.isGameover = false;
		GameManager.isMoving = false;
		holeVertices = new List<int>();
		offsets = new List<Vector3>();
		mesh = meshFilter.mesh;
		FindHoleVertices();
	}

	void Update()
	{
		#if UNITY_EDITOR
				GameManager.isMoving = Input.GetMouseButton(0);  //UNITY TOUCH KONTROLÜ
		#else
				GameManager.isMoving = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved;  //MOBİL TOUCH KONTROLÜ
		#endif
		if (!GameManager.isGameover && GameManager.isMoving && GameManager.phaseOneDone && !GameManager.phaseTwoDone)
		{
			MoveHole();
			UpdateHoleVerticesPosition();
		}
	}

	void MoveHole()
	{
		x = Input.GetAxis("Mouse X");
		y = Input.GetAxis("Mouse Y");

		touch = Vector3.Lerp(HoleCenter.position, HoleCenter.position + new Vector3(x, 0f, y), moveSpeed * Time.deltaTime);
		targetPos = new Vector3(Mathf.Clamp(touch.x, -1 * movementLimits.x, movementLimits.x), touch.y, Mathf.Clamp(touch.z, -1 * movementLimits.y, movementLimits.y));
		HoleCenter.position = targetPos;
	}

	void UpdateHoleVerticesPosition()
	{
		Vector3[] vertices = mesh.vertices;
		for (int i = 0; i < holeVerticesCount; i++)
		{
			vertices[holeVertices[i]] = HoleCenter.position + offsets[i];
		}

		mesh.vertices = vertices;
		meshFilter.mesh = mesh;
		meshCollider.sharedMesh = mesh;
	}

	void FindHoleVertices()
	{
		for (int i = 0; i < mesh.vertices.Length; i++)
		{
			float distance = Vector3.Distance(HoleCenter.position, mesh.vertices[i]);
			if (distance < radius)
			{
				holeVertices.Add(i);
				offsets.Add(mesh.vertices[i] - HoleCenter.position);
			}

		}

		holeVerticesCount = holeVertices.Count;
	}
}
