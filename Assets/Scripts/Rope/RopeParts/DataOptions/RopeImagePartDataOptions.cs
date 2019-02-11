using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeImagePartDataOptions : MonoBehaviour, IRopePartDataOptions
{
	[SerializeField]
	private Transform carTransform;
	public Transform CarTransform
	{
		get { return carTransform; }
		set { carTransform = value; }
	}

	[SerializeField]
	private Transform carImageTransform;
	public Transform CarImageTransform
	{
		get { return carImageTransform; }
		set { carImageTransform = value; }
	}

	[SerializeField]
	[Range(0, 1)]
	private float carFlyingRotationWeightKoef = 0.7f; //This koef connected with how strong car image looking to velocity direction, when car flying
	public float CarFlyingRotationWeightKoef
	{
		get { return carFlyingRotationWeightKoef; }
		set { carFlyingRotationWeightKoef = value; }
	}

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
		ropePart = new RopeImagePart(ropeController, this);
	}
}
