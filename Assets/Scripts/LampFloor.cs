using UnityEngine;
using System.Collections;

public class LampFloor : MonoBehaviour
{

	public Vector3 spawn;
	static bool swapSide = false;

	void Start()
	{
		if (swapSide) {
			spawn.x = -spawn.x;
		}
		
		swapSide = !swapSide;

		transform.position += spawn;
	}
}
