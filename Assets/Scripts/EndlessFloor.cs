using UnityEngine;
using System.Collections;

public class EndlessFloor : MonoBehaviour
{

	public int offset = 0;

	void OnTriggerEnter(Collider other) {
		Vector3 pos = other.transform.position;
		pos.z -= offset;
		other.transform.position = pos;
	}
}
