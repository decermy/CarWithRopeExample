using UnityEngine;
public class Rope : IRope
{
	private LineRenderer lineRenderer;
	private DistanceJoint2D distanceJoint2D;

	public Rope(LineRenderer lineRenderer, DistanceJoint2D distanceJoint2D)
	{
		this.lineRenderer = lineRenderer;
		this.distanceJoint2D = distanceJoint2D;
	}

	public void CreateRope()
	{
		distanceJoint2D.enabled = true;
		lineRenderer.enabled = true;
	}

	public void RemoveRope()
	{
		distanceJoint2D.enabled = false;
		lineRenderer.enabled = false;
	}
}
