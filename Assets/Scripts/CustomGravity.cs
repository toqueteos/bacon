using UnityEngine;
using System.Collections;

public class CustomGravity : MonoBehaviour
{

	public float force = 9.8f;

	void FixedUpdate()
	{
		Vector3 f = Vector3.up * -force * Time.fixedDeltaTime;
		rigidbody.AddForce(f, ForceMode.VelocityChange);
	}

}
