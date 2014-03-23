using UnityEngine;
using System.Collections;

public class FadeDestroy : MonoBehaviour
{

	public Transform player;
	public float destroyDistance = 32;
	// Don't start fading unless distance D
	public float startFadeAfter = 8;
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
		float alpha = Mathf.Max(0f, (dist - startFadeAfter) / destroyDistance);
		c.a = 1f - alpha;
		if (c.a <= 0) {
			Destroy(gameObject);
		} else {
			mr.material.color = c;
		}
	}
}
