﻿using UnityEngine;
using System.Collections;

public class TriggerDestroy : MonoBehaviour
{

	public Transform owner;
	public float ensureDestroyAfter = 5f;

	void Update()
	{
		ensureDestroyAfter -= Time.deltaTime;
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