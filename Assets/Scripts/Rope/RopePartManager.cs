using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRartsManager : IRopePartManager
{
	[SerializeField]
	private RopeController ropeController;

	public void InitRopePartDataOptions(RopeController ropeController, IRopePartDataOptions[] ropePartDatas)
	{
		for (int i = 0; i < ropePartDatas.Length; i++)
		{
			ropePartDatas[i].Init(ropeController);
		}
	}

	public void SubscribeRopePartsOnUpdate(bool subscribe, IRopePartDataOptions[] ropePartDatas)
	{
		for (int i = 0; i < ropePartDatas.Length; i++)
		{
			ropePartDatas[i].RopePart.SubscribeOnUpdate(subscribe);
		}
	}
}
