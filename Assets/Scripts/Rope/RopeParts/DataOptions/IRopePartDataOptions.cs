using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRopePartDataOptions
{
	IRopePart RopePart { get; set; }

	void Init(RopeController ropeController);
}
