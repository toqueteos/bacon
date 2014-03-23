using UnityEngine;
using System.Collections;

public class TriggerDestroy : MonoBehaviour
{

	public Transform owner;

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.name != owner.name)
		{
			return;
		}

		Destroy(gameObject);
	}
}
