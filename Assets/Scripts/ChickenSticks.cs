﻿using UnityEngine;
using System.Collections;

public class ChickenSticks : MonoBehaviour {

	private Vector3 pos;
	static int nameId = 0;
	
	// Use this for initialization
	void Start () {
		name = string.Format("chickensticks{0}", nameId);
		nameId++;	
	}
}
