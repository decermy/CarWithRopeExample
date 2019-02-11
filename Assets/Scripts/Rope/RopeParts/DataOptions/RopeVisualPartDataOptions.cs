using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeVisualPartDataOptions : MonoBehaviour, IRopePartDataOptions
{
	[SerializeField]
	private LineRenderer lineRenderer;
	public LineRenderer LineRenderer
	{
		get { return lineRenderer; }
		set { lineRenderer = value; }
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
		ropePart = new RopeVisualPart(ropeController, this);
	}
}
