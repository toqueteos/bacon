﻿using UnityEngine;
using System.Collections;

public class Gyoza : MonoBehaviour {

	private Vector3 pos;
	FadeDestroy fd;
	static int nameId = 0;
	
	// Use this for initialization
	void Start () {
		fd = GetComponent<FadeDestroy>();
		name = string.Format("gyoza{0}", nameId);
		nameId++;	
		pos = fd.player.transform.position;
		pos.z -= Random.Range(6f,9f);
		pos.y = 1f;
		pos.x = Random.Range(-6.5f,6.5f);
		transform.position = pos;
	}
}
