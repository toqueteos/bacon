using UnityEngine;
using System.Collections;

public class Fork : MonoBehaviour
{

	private Vector3 pos;
	private float counter; // countdown to fall
	
	private float timeUntilFall = 4f;

	static int nameId = 0;
	
	FadeDestroy fd;

	public Vector2 sidewaysRotation = new Vector2(-15f, 15f);

	void Start()
	{
		fd = GetComponent<FadeDestroy>();
		
		counter = timeUntilFall;
		
		name = string.Format("fork{0}", nameId);
		nameId++;
		
		pos = fd.player.transform.position;
		pos.z += 0f;
		pos.y = 8f;
		pos.x = Random.Range(-6.5f,6.5f);

		// Set position and ignore forces/torques
		transform.position = pos;

		// Slightly rotate fork sideways
		float rot = Random.Range(sidewaysRotation.x, sidewaysRotation.y);
		transform.rotation = Quaternion.Euler(0, 0, rot);
	}

	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;
		if(counter<=0)
		{
			if(transform.position.y<=0)
			{
				transform.rigidbody.useGravity = false;
			}
			else
			{
				transform.rigidbody.useGravity = true;
				transform.rigidbody.AddForce(Vector3.down * 200);
			}
		}
		else
		{
			pos = transform.position;
			pos.z = fd.player.transform.position.z;
			transform.position = pos;
		}
	}

	void OnCollisionEnter(Collision collision) {
		transform.rigidbody.useGravity = false;
		transform.rigidbody.detectCollisions = false;
		transform.rigidbody.freezeRotation = true;
		transform.rigidbody.drag = 2000;
		enabled = false;
	}
	
}
