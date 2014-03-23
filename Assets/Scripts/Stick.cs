using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour
{

	static int nameId = 0;
	public Vector3 spawn;
	public Vector2 randomX;
	public GameObject shadow;

	void Start()
	{
		name = string.Format("stick{0}", nameId);
		nameId++;

		spawn.x = Random.Range(randomX.x, randomX.y);
		transform.position += spawn;

		Ray ray = new Ray(transform.position, -Vector3.up);
		RaycastHit hit;
		
		if (!Physics.Raycast(ray, out hit)) {
			return;
		}
		
		GameObject go = Instantiate(shadow, hit.point, Quaternion.identity) as GameObject;
		TriggerDestroy td = go.GetComponent<TriggerDestroy>();
		td.owner = transform;
	}
}
