using UnityEngine;
using System.Collections;

public class Fork : MonoBehaviour
{

	public Vector2 sidewaysRotation = new Vector2(-15f, 15f);
	// How far from floor does gravity stop working?
	public float floorOffset = 0.1f;
	public float gravity = 9.8f;

	void Start()
	{
		// Slightly rotate fork sideways
		float rot = Random.Range(sidewaysRotation.x, sidewaysRotation.y);
		transform.rotation = Quaternion.Euler(0, 0, rot);
	}
	
	void Update()
	{
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 1024f))
		{
			Vector3 to = -transform.up * hit.distance;
			Debug.DrawRay(transform.position, to, Color.red, 5f);
		}

		// Apply gravity
		if (hit.distance >= floorOffset)
		{
			Vector3 pos = transform.position;
			pos.y -= gravity * Time.deltaTime;
			transform.position = pos;
		}
	}
}
