using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
	[SerializeField]
	private float lerpSpeed = 10;
	[SerializeField]
	private RopeController ropeController;

	private Camera cam;

	private void Awake()
	{
		Initialize();
	}

	private void OnEnable()
	{
		ropeController.fixedUpdateEvent += OnUpdate;
	}

	private void OnDisable()
	{
		ropeController.fixedUpdateEvent -= OnUpdate;
	}

	/// <summary>
	/// must be use fixed update
	/// </summary>
	private void Initialize()
	{
		cam = GetComponent<Camera>();

		if (ropeController == null)
		{
			Debug.LogError("camera Initialize Failed");
			return;
		}

		Debug.Log("camera Initialized");
	}


	private void CameraLerpMovement()
	{
		Vector3 newPosition = ropeController.transform.position;
		newPosition.z = transform.position.z;

		transform.position = Vector3.Lerp(transform.position, newPosition, Time.fixedDeltaTime * lerpSpeed);
	}

	public Vector3 GetPointWorldPosition()
	{
		Vector2 mousePos = Input.mousePosition;

		return cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
	}

	private void OnUpdate()
	{
		CameraLerpMovement();
	}
}
