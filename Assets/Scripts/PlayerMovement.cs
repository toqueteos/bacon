using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	CharacterController cc;
	public float speed = 8f;
	public float lateralSpeed = 6f;
	public float rotationSpeed = 1f;
	float floorOffset = 0.65f;
	float gravity = 9.8f;
	bool onJump = false;
	public bool canJump = true;
	public float jumpForce = 20.0f;
	float jForce;
	Quaternion defRotation;
	Animator anim;
	
	void Start()
	{
		cc = GetComponent<CharacterController>();

		anim = GetComponent<Animator>();

		if (cc == null)
		{
			Debug.LogError("CharacterController component is missing.");
		}

		defRotation = transform.rotation;

		jForce = 0f;
	}
	
	void Update()
	{
		// Start movement
		bool slmove = Input.GetKeyDown(KeyCode.LeftArrow);
		bool srmove = Input.GetKeyDown(KeyCode.RightArrow);

		// While moving
		bool lmove = Input.GetKey(KeyCode.LeftArrow);
		bool rmove = Input.GetKey(KeyCode.RightArrow);

		// End movement
		bool elmove = Input.GetKeyUp(KeyCode.LeftArrow);
		bool ermove = Input.GetKeyUp(KeyCode.RightArrow);

		// Start jump
		bool jump = Input.GetKeyDown(KeyCode.Space);

		// Default rotation (facing camera)
		float rotx = defRotation.eulerAngles.x;
		float roty = defRotation.eulerAngles.y;
		float rotz = defRotation.eulerAngles.z;

		// Rotation speed multiplier (modify for start-end movements, quicker on start)
		float sp = rotationSpeed * 0.01f;


		// We reset rotation first (if triggered)
		if (elmove || ermove)
		{
			roty = 0f;
			sp = rotationSpeed * 0.005f;
			anim.SetBool("FrontJump", true);
		}

		if (slmove || srmove)
		{
			anim.SetBool("FrontJump", false);
		} else
		{
			anim.SetBool("FrontJump", true);
		}

		// Then we can aply the animation and a new rotation
		if (lmove)
		{
			roty = 15f;
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("LeftJump") == false)
			{
				anim.SetTrigger("LeftJump");
			}
		}
		if (rmove)
		{
			roty = -15f;
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("RightJump") == false)
			{
				anim.SetTrigger("RightJump");
			}
		}

		// New rotation quaternion and a lerp for smoothness
		Quaternion toRotation = Quaternion.Euler(rotx, roty, rotz);
		transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.time * sp);

		// Temporary position vector
		Vector3 pos = transform.position;

		// Forward
		pos.z += -speed * Time.deltaTime;

		// Lateral movement
		if (lmove)
		{
			pos.x += -lateralSpeed * Time.deltaTime;
		}
		if (rmove)
		{
			pos.x += lateralSpeed * Time.deltaTime;
		}

		// Keep player on the rail
		float limit = 6.5f;
		pos.x = Mathf.Clamp(pos.x, -limit, limit);

		// Jump
		if (jump && canJump == true)
		{
			jForce = jumpForce;
			canJump = false;
			onJump = true;
		}

		if (onJump)
		{
			jForce -= gravity * Time.deltaTime;
			if (jForce <= 0)
			{
				jForce = 0f;
			}
		}

		// Fake gravity
		pos.y += (-gravity + jForce) * Time.deltaTime;

		// Apply transform
		transform.position = Vector3.Lerp(transform.position, pos, 50f * Time.deltaTime);

		// Height correction
		if (transform.position.y < floorOffset)
		{
			transform.position = new Vector3(transform.position.x, floorOffset, transform.position.z);
			canJump = true;
			onJump = false;
			jForce = 0f;
		}
	}
}