using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(DistanceJoint2D))]
[RequireComponent(typeof(Collider2D))]
public class RopeController : MonoBehaviour
{
	[SerializeField]
	private GameObject pointImage;
	[SerializeField]
	private Transform ropeConnectionPoint;
	public Transform RopeConnectionPoint
	{
		get { return ropeConnectionPoint; }
	}

	[SerializeField]
	private GameObject gameobjectWithRopePartsData;

	[SerializeField]
	private Camera cam;

	public delegate void SimpleUpdateEvent();

	public event SimpleUpdateEvent updateEvent;
	public event SimpleUpdateEvent fixedUpdateEvent;
	public event SimpleUpdateEvent lateUpdateEvent;

	private IRope rope;

	private LineRenderer lineRenderer;
	private DistanceJoint2D distanceJoint2D;
	private Rigidbody2D rb2D;
	public Rigidbody2D Rb2D
	{
		get { return rb2D; }
	}

	private CameraController cameraController;
	private IRopePartManager ropePartManager;
	private IRopePartDataOptions[] ropePartDatas;

	//state flag
	private bool ropeActive = true;
	public bool RopeActive
	{
		get { return ropeActive; }
	}

	private void Awake()
	{
		SetFields();

		if (gameobjectWithRopePartsData == null)
		{
			Debug.LogError("RopePartData missed");
		}

		SetManager();
	}

	private void SetManager()
	{
		ropePartDatas = gameobjectWithRopePartsData.GetComponents<IRopePartDataOptions>();

		ropePartManager = new RopeRartsManager();
		ropePartManager.InitRopePartDataOptions(this, ropePartDatas);
	}

	private void OnEnable()
	{
		ropePartManager.SubscribeRopePartsOnUpdate(true, ropePartDatas);
	}
	private void OnDisable()
	{
		ropePartManager.SubscribeRopePartsOnUpdate(false, ropePartDatas);
	}

	private void SetFields()
	{
		lineRenderer = GetComponent<LineRenderer>();
		distanceJoint2D = GetComponent<DistanceJoint2D>();
		rb2D = GetComponent<Rigidbody2D>();

		cameraController = cam.GetComponent<CameraController>();

		if (pointImage == null || ropeConnectionPoint == null || cam == null || lineRenderer == null || distanceJoint2D == null || rb2D == null || cameraController == null)
		{
			Debug.LogError("RopeController Initialize Failed");
			return;
		}
	}

	private void Start()
	{
		StartSets();

		rope = new Rope(lineRenderer, distanceJoint2D);
	}

	private void StartSets()
	{
		lineRenderer.positionCount = 2;
	}

	private void Update()
	{
		if (updateEvent != null)
		{
			updateEvent.Invoke();
		}
	}
	private void FixedUpdate()
	{
		if (fixedUpdateEvent != null)
		{
			fixedUpdateEvent.Invoke();
		}
	}

	private void LateUpdate()
	{
		if (lateUpdateEvent != null)
		{
			lateUpdateEvent.Invoke();
		}
	}

	private void CreateRope()
	{
		ropeActive = !ropeActive;
		CreateRope(ropeActive);
	}

	/// <summary>
	/// replace point, activate rope
	/// </summary>
	private void CreateRope(bool active)
	{
		if (!enabled)
		{
			return;
		}

		if (active)
		{
			rope.CreateRope();

			Vector3 RopePointNewWorldPosition = cameraController.GetPointWorldPosition();
			SetNewPointPosition(RopePointNewWorldPosition);
		}
		else
		{
			rope.RemoveRope();
		}

		AcivatePoint(active);
	}

	private void SetNewPointPosition(Vector3 worldPos)
	{
		Vector3 connectionPintPos = ropeConnectionPoint.position;
		connectionPintPos.x = worldPos.x;
		connectionPintPos.y = worldPos.y;
		ropeConnectionPoint.position = connectionPintPos;
	}

	private void AcivatePoint(bool active)
	{
		pointImage.gameObject.SetActive(active);
	}

	/// <summary>
	/// Will calls through event
	/// </summary>
	public void OnActionWithRope()
	{
		CreateRope();
	}


}
