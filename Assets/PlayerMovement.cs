using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	CharacterController cc;
	public Vector3 speed = Vector3.forward;


	public float lateralSpeed = 6f;
	public float rotationSpeed = 1f;

	Quaternion defRotation;
	
	void Start()
	{

		cc = GetComponent<CharacterController>();

		if (cc == null)
		{
			Debug.LogError("CharacterController component is missing.");
		}

		defRotation = transform.rotation;

	}
	
	void Update()
	{
		// Start movement
		// Quick hack: chenged GetKeyDown with GetKey
		bool slmove = Input.GetKey(KeyCode.LeftArrow);
		bool srmove = Input.GetKey(KeyCode.RightArrow);

		// End movement
		bool elmove = Input.GetKeyUp(KeyCode.LeftArrow);
		bool ermove = Input.GetKeyUp(KeyCode.RightArrow);

		// Default rotation (facing camera)
		float rotx = defRotation.eulerAngles.x;
		float roty = defRotation.eulerAngles.y;
		float rotz = defRotation.eulerAngles.z;

		// Rotation speed multiplier (modify for start-end movements, quicker on start)
		float sp = rotationSpeed * 0.01f;

		// We reset rotation first (if triggered)
		if(elmove||ermove)
		{
			roty = 0f;
			sp = rotationSpeed * 0.005f;
		}

		// Then we can aply a new rotation
		if(slmove)
		{
			roty = 30f;
		}
		if(srmove)
		{
			roty = -30f;
		}

		// New rotation quaternion and a lerp for smoothness
		Quaternion toRotation = Quaternion.Euler(rotx, roty, rotz);
		transform.rotation = Quaternion.Lerp (transform.rotation, toRotation, Time.time * sp);

		// Jump
		bool jump = Input.GetKeyDown(KeyCode.Space);

		if(jump)
		{
			Debug.Log("JUMP");
		}

		// Movement blabla
		bool lmove = Input.GetKey(KeyCode.LeftArrow);
		bool rmove = Input.GetKey(KeyCode.RightArrow);
		speed.x = 0;
		if(lmove)
		{
			speed.x = lateralSpeed;
		}
		if(rmove)
		{
			speed.x = -lateralSpeed;
		}
		
		// Move player
		cc.SimpleMove(-speed);
		
		float limit = 6.5f;
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp(pos.x, -limit, limit);
		transform.position = pos;
		
		
	}
}