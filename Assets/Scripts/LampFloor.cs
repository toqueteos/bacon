using UnityEngine;
using System.Collections;

public class LampFloor : MonoBehaviour
{

	public Vector3 spawn;
	static bool swapSide = false;
	static int nameId = 0;

	void Start()
	{
		name = string.Format("lampfloor{0}", nameId);
		nameId++;
		if (swapSide) {
			spawn.x = -spawn.x;
		}
		
		swapSide = !swapSide;

		transform.position += spawn;
	}
}
