using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Boundary 
{
	public const float minX= -500f;
	public const float maxX= 500f;
	public const float minY= -100f;
	public const float maxY= 100f;
	public const float minZ= -500f;
	public const float maxZ= 500f;

	public static Vector3 GenerateBoundary()
	{
		float x = Random.Range (minX, maxX);
		float y = Random.Range (minY, maxY);
		float z = Random.Range (minZ, maxZ);

		return new Vector3 (x, y, z);
	}
}
