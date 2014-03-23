using UnityEngine;
using System.Collections;

public class TriggerDestroy : MonoBehaviour
{

	public Transform owner;
	public float ensureDestroyAfter = 2f;

	void Update()
	{
		ensureDestroyAfter -= Time.deltaTime;

		if (ensureDestroyAfter <= 0) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.name != owner.name)
		{
			return;
		}

		Destroy(gameObject);
	}
}
