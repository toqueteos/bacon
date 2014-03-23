using UnityEngine;
using System.Collections;

public class FadeDestroy : MonoBehaviour
{

	public Transform player;
	public float destroyDistance;
	MeshRenderer mr;
	Color c;
	
	void Start()
	{
		mr = GetComponentInChildren<MeshRenderer>();
		c = mr.material.color;
	}

	void Update()
	{
		float dist = Vector3.Distance(player.position, transform.position);

		c.a = 1f - (dist / destroyDistance);
		if (c.a <= 0) {
			Destroy(gameObject);
		} else {
			mr.material.color = c;
		}
	}
}
