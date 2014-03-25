using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour
{
	
	static int nameId = 0;
	public Vector3 spawn;
	public Vector2 randomX;
	public Vector2 randomZ;
	public GameObject shadow;
	
	void Start()
	{
		name = string.Format("stick{0}", nameId);
		nameId++;
		
		spawn.x = Random.Range(randomX.x, randomX.y);
		float z = spawn.z;
		spawn.z = z-= Random.Range(randomZ.x, randomZ.y);
		transform.position += spawn;
		
		Ray ray = new Ray(transform.position, -Vector3.up);
		RaycastHit hit;
		
		if (!Physics.Raycast(ray, out hit)) {
			return;
		}

		transform.tag = "Enemy";
		
		GameObject go = Instantiate(shadow, hit.point, Quaternion.identity) as GameObject;
		TriggerDestroy td = go.GetComponent<TriggerDestroy>();
		td.owner = transform;
	}
}