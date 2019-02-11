using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorData", menuName = "Data/ColorData")]
public class ColorsData : ScriptableObject
{
	[SerializeField]
	private Color ropeColor;
	public Color RopeColor
	{
		get { return ropeColor; }
		set { ropeColor = value; }
	}

	[SerializeField]
	private float ropeWidth;
	public float RopeWidth
	{
		get { return ropeWidth; }
		set { ropeWidth = value; }
	}

	[SerializeField]
	private Color pointColor;
	public Color PointColor
	{
		get { return pointColor; }
		set { pointColor = value; }
	}

	[SerializeField]
	private Color carColor;
	public Color CarColor
	{
		get { return carColor; }
		set { carColor = value; }
	}
}
