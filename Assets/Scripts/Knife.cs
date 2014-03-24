using UnityEngine;
using System.Collections;

public class Knife : MonoBehaviour {

	private Vector3 pos;
	private float counter; // countdown to fall

	private float timeUntilFall = 2f;
	private float distanceToPlayer;

	static int nameId = 0;

	private bool bump;

	private bool startedFalling = false;

	FadeDestroy fd;

	// Use this for initialization
	void Start () {

		bump = false;

		fd = GetComponent<FadeDestroy>();

		counter = timeUntilFall;

		name = string.Format("knife{0}", nameId);
		nameId++;

		transform.tag = "Untagged"; // not an enemy until it starts falling

		pos = fd.player.transform.position;
		pos.z -= 4f;
		pos.y = 5.5f;
		pos.x = -6.5f + Mathf.Floor(Random.value+0.5f)*13f;

		// Handle rotation
		float dir = 1f;
		float ry = 0;
		if(pos.x>=0)
		{
			ry = 180f;
			dir = -1f;
		}
		float rz = 5f * dir; // tilt the handle a little
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, ry, rz);

		// Fix distance to player while hovering
		distanceToPlayer = -4f;

		// Set position and ignore forces/torques
		transform.position = pos;
		transform.rigidbody.useGravity = false; // Disable gravity
		transform.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

		//Debug.Log(string.Format("New knife created at {0}", pos));
	}
	
	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;
		if(counter<=0)
		{
			if(!startedFalling)
			{
				startedFalling = true;
				transform.tag = "Enemy";
			}
			if(transform.position.y<=0)
			{
				if(!bump)
				{
					transform.rigidbody.useGravity = false;
					transform.rigidbody.constraints = RigidbodyConstraints.FreezePosition;
				}
			}
			else
			{
				if(bump)
				{
					transform.rigidbody.constraints = RigidbodyConstraints.None;
					transform.rigidbody.useGravity = true;
					transform.rigidbody.detectCollisions = true;
				}
				else
				{
					float dir = 1f;
					if(transform.position.x>0)
					{
						dir = -1f;
					}
					transform.rigidbody.useGravity = true;
					transform.rigidbody.AddForce(Vector3.down * 700);
					transform.rigidbody.AddTorque(Vector3.back * 80 * dir);
				}
			}
		}
		else
		{
			pos = transform.position;
			pos.z = fd.player.transform.position.z + distanceToPlayer;
			transform.position = pos;
			distanceToPlayer += 5f*Time.deltaTime;
			if(distanceToPlayer>0f)
			{
				distanceToPlayer = 0f;
			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		if(transform.position.y>0)
		{
			bump = true;
		}
	}
}
