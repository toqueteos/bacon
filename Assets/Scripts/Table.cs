using UnityEngine;
using System.Collections;

public class Table : MonoBehaviour {

	private Vector3 pos;
	FadeDestroy fd;
	static int nameId = 0;
	
	// Use this for initialization
	void Start () {
		fd = GetComponent<FadeDestroy>();
		name = string.Format("table{0}", nameId);
		nameId++;	
		pos = fd.player.transform.position;
		pos.z -= 24f;
		pos.y = 0f;
		pos.x = Mathf.Floor(Random.value+0.5f)*120f;
		transform.position = pos;
	}
}
