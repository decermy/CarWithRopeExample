using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsController : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer car;
	[SerializeField]
	private SpriteRenderer point;
	[SerializeField]
	private LineRenderer line;

	[SerializeField]
	private ColorsData colorsData;

	private void Awake()
	{
		SetColors();
	}

	public void SetColors()
	{
		car.color = colorsData.CarColor;
		point.color = colorsData.PointColor;

		line.startColor = colorsData.RopeColor;
		line.endColor = colorsData.RopeColor;
		line.widthMultiplier = colorsData.RopeWidth;
	}
}
