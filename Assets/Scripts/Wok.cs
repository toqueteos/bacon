using UnityEngine;
using System.Collections;

public class Wok : MonoBehaviour {

	private Vector3 pos;
	FadeDestroy fd;
	static int nameId = 0;
	
	// Use this for initialization
	void Start () {
		fd = GetComponent<FadeDestroy>();
		name = string.Format("wok{0}", nameId);
		nameId++;	
		pos = fd.player.transform.position;
		pos.z -= Random.Range(20f,25f);
		pos.y = 3f;
		pos.x = Random.Range(-2.5f,2.5f);
		transform.position = pos;
	}
}
