using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePhysicsPartDataOptions : MonoBehaviour, IRopePartDataOptions
{
	[SerializeField]
	private float maxSpeed = 10;
	public float MaxSpeed
	{
		get { return maxSpeed; }
		set { maxSpeed = value; }
	}

	private RopeController ropeController;

	private IRopePart ropePart;
	public IRopePart RopePart
	{
		get
		{
			return ropePart;
		}
		set
		{
			ropePart = value;
		}
	}

	public void Init(RopeController ropeController)
	{
		ropePart = new RopePhysicsPart(ropeController, this);
	}
}
