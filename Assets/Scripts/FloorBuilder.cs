using UnityEngine;
using System.Collections;

public class FloorBuilder : MonoBehaviour
{

	public Transform floorBelt;
	public int beltSize = 32;
	public int qty = 8;

	void Start()
	{
		for (int i = 0; i < qty; i++)
		{
			Transform go = Instantiate(floorBelt) as Transform;
			go.position = Vector3.forward * i * beltSize;
			go.parent = transform;
			go.name = string.Format("belt{0}", i);
		}
	}
}
