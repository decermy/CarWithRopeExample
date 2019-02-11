using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePhysicsPart : IRopePart
{
	private RopePhysicsPartDataOptions ropePhysicsPartData;

	private RopeController ropeController;

	public RopePhysicsPart(RopeController ropeController, RopePhysicsPartDataOptions ropePhysicsPartData)
	{
		if (ropeController == null)
		{
			Debug.LogError("physicsPart Initialize Failed");
			return;
		}

		this.ropeController = ropeController;
		this.ropePhysicsPartData = ropePhysicsPartData;

		Debug.Log("physicsPart Initialized");
	}

	/// <summary>
	/// Clamp speed: do it only then car flying, don't when car pinned
	/// </summary>
	private void ClampSpeed(Rigidbody2D rb2D, bool isRopeActive)
	{
		if (!isRopeActive && rb2D.velocity.magnitude > ropePhysicsPartData.MaxSpeed)
		{
			rb2D.velocity = rb2D.velocity.normalized * ropePhysicsPartData.MaxSpeed;
		}
	}

	/// <summary>
	/// must be use fixed update
	/// </summary>
	public void OnUpdate()
	{
		ClampSpeed(ropeController.Rb2D, ropeController.RopeActive);
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
