using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeVisualPart : IRopePart
{
	private RopeVisualPartDataOptions ropeVisualPartData;

	private RopeController ropeController;

	public RopeVisualPart(RopeController ropeController, RopeVisualPartDataOptions ropeVisualPartData)
	{
		if (ropeController == null || ropeVisualPartData.LineRenderer == null)
		{
			Debug.LogError("visualPart Initialize Failed");
			return;
		}

		this.ropeController = ropeController;
		this.ropeVisualPartData = ropeVisualPartData;

		Debug.Log("visualPart Initialized");
	}

	/// <summary>
	/// draw line between two points
	/// </summary>
	private void UpdateGraphics(Vector3 point1, Vector3 point2)
	{
		ropeVisualPartData.LineRenderer.positionCount = 2;
		ropeVisualPartData.LineRenderer.SetPositions(new Vector3[] { point1, point2 });
	}

	/// <summary>
	/// must be use late update
	/// </summary>
	public void OnUpdate()
	{
		UpdateGraphics(ropeController.RopeConnectionPoint.position, ropeController.transform.position);
	}

	public void SubscribeOnUpdate(bool subscribe)
	{
		if (subscribe)
		{
			ropeController.lateUpdateEvent += OnUpdate;
		}
		else
		{
			ropeController.lateUpdateEvent -= OnUpdate;
		}
	}
}
