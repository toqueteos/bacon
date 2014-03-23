using UnityEngine;
using System.Collections;

public class JapaneseDoor : MonoBehaviour {

	private Vector3 pos;
	FadeDestroy fd;
	static int nameId = 0;
	
	// Use this for initialization
	void Start () {
		fd = GetComponent<FadeDestroy>();
		name = string.Format("japanesedoor{0}", nameId);
		nameId++;	
		pos = fd.player.transform.position;
		pos.z -= 24f;
		pos.y = 0f;
		pos.x = -35f + Mathf.Floor(Random.value+0.5f)*70f;

		// Handle rotation
		float ry = 0;
		if(pos.x>0)
		{
			ry = 180f;
		}
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, ry, transform.rotation.eulerAngles.z);

		transform.position = pos;
	}
}
