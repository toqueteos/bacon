﻿using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(CharacterController))]
public class TriggerMovement : MonoBehaviour
{
	public FloorBuilder fb;
	int floorOffset;
	public Transform player;
	// How far should the trigger be from the player
	public float awayAtMost = 0.85f;
	public Vector3 speed;
	public float positionDelta = 0.05f;

	void Start() {
		floorOffset = fb.qty * fb.beltSize;
		transform.position = Vector3.forward * (floorOffset - (fb.beltSize / 2));
	}

	void Update()
	{
		float dist = Vector3.Distance(player.position, transform.position);

		float maxDistance = floorOffset * awayAtMost;
		if (dist >= maxDistance) {
			speed.z += positionDelta;
		} else {
			speed.z -= positionDelta;
		}

		// Ensure speed is always 0 or more
		speed.z = Mathf.Max(0, speed.z);

		transform.position -= speed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other) {
		Vector3 pos = other.transform.position;
		pos.z -= floorOffset;
		other.transform.position = pos;
	}
}
