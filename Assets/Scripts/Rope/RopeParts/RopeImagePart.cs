using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeImagePart : IRopePart
{
	private RopeImagePartDataOptions ropeImagePartData;
	private RopeController ropeController;

	private Quaternion leftRotation = Quaternion.Euler(Vector3.up * 180);
	private Quaternion rightRotation = Quaternion.Euler(Vector3.up * 0);

	private Vector2 lastUsedVelocity = Vector2.right;

	public RopeImagePart(RopeController ropeController, RopeImagePartDataOptions ropeImagePartData)
	{

		if (ropeController == null || ropeImagePartData.CarTransform == null || ropeImagePartData.CarImageTransform == null)
		{
			Debug.LogError("imagePart Initialize Failed");
			return;
		}

		this.ropeImagePartData = ropeImagePartData;
		this.ropeController = ropeController;

		Debug.Log("imagePart Initialized");
	}

	/// <summary>
	/// select update type
	/// </summary>
	private void UpdateImageRotation(Vector3 pointPosition, Vector3 ropePosition, Vector2 velocityDirection, bool ropeActive)
	{
		if (ropeActive)
		{
			UpdatePinnedRotation(pointPosition, ropePosition, velocityDirection);
		}
		else
		{
			UpdateFlyingRotation(velocityDirection);
		}

		lastUsedVelocity = velocityDirection;
	}

	/// <summary>
	/// When rope pinned, car always ortogonal to rope line, also car image must looking to velocity direction
	/// </summary>
	private void UpdatePinnedRotation(Vector3 pointPosition, Vector3 ropePosition, Vector2 velocityDirection)
	{
		Vector3 carUpDir = pointPosition - ropePosition;

		if (Vector3.Cross(carUpDir.normalized, velocityDirection.normalized).z > 0) // if car have same direction as velocity
		{
			ropeImagePartData.CarImageTransform.localRotation = leftRotation; // normal
		}
		else
		{
			ropeImagePartData.CarImageTransform.localRotation = rightRotation; //mirror
		}

		Quaternion imageRotation = Quaternion.LookRotation(Vector3.forward, carUpDir); //ortogonal to rope line
		ropeImagePartData.CarTransform.rotation = imageRotation;
	}

	/// <summary>
	/// When car flying, car Image looking to velocity direction 
	/// </summary>
	private void UpdateFlyingRotation(Vector2 velocityDirection)
	{
		float angle = Vector2.Angle(lastUsedVelocity, velocityDirection);
		float cross = Vector3.Cross(lastUsedVelocity.normalized, velocityDirection.normalized).z;

		cross = cross > 0 ? 1 : -1;

		ropeImagePartData.CarTransform.RotateAround(ropeImagePartData.CarTransform.position, Vector3.forward, angle * cross * ropeImagePartData.CarFlyingRotationWeightKoef);
	}

	/// <summary>
	/// must be use fixed update
	/// </summary>
	public void OnUpdate()
	{
		UpdateImageRotation(ropeController.RopeConnectionPoint.position, ropeController.transform.position, ropeController.Rb2D.velocity, ropeController.RopeActive);
	}

	public void SubscribeOnUpdate(bool subscribe)
	{
		if (subscribe)
		{
			ropeController.fixedUpdateEvent += OnUpdate;
		}
		else
		{
			ropeController.fixedUpdateEvent -= OnUpdate;
		}
	}
}
