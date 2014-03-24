using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	CharacterController cc;
	public float speed = 8f;
	public float lateralSpeed = 6f;
	public float rotationSpeed = 1f;
	public float lateralRotation = 15f;
	
	public float gravity = 9.8f;
	public float jumpForce = 8.0f;
	public bool onJump = false;

	public float pushPower = 2.0f;
	
	public Vector3 moveDirection = Vector3.zero;
	
	public AudioSource jumpSound;
	public AudioSource hitSound;
	
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
		
	}
	
	void Update()
	{

		// Default rotation (facing camera)
		float rotx = defRotation.eulerAngles.x;
		float roty = defRotation.eulerAngles.y;
		float rotz = defRotation.eulerAngles.z;

		// Start jump
		bool jump = (Input.GetAxis("Vertical")>0); //Input.GetKey(KeyCode.Space);
				
		if (Input.GetAxis("Horizontal")==0f)
		{
			roty = 0f;
			anim.SetBool("FrontJump", true);
		}
		
		// Then we can aply the animation and a new rotation
		if (Input.GetAxis("Horizontal")<0f)
		{
			roty = lateralRotation;
			if (!anim.GetCurrentAnimatorStateInfo(0).IsName("LeftJump"))
			{
				anim.SetBool("FrontJump", false);
				anim.SetTrigger("LeftJump");
			}
		}
		if (Input.GetAxis("Horizontal")>0f)
		{
			roty = -lateralRotation;
			if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RightJump"))
			{
				anim.SetBool("FrontJump", false);
				anim.SetTrigger("RightJump");
			}
		}
		
		// New rotation quaternion and a lerp for smoothness
		Quaternion toRotation = Quaternion.Euler(rotx, roty, rotz);
		transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.time * rotationSpeed);
		
		
		// Movement
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, -1f);
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		
		
		// Jump
		if (cc.isGrounded)
		{
			if(jump) // START JUMP
			{
				jumpSound.Play();
				moveDirection.y = jumpForce;
				Debug.Log ("Started jump");
				onJump = true;
			}
		}
		else
		{
			if(onJump)
			{
				moveDirection.y = Mathf.Sin (-180f+2f*Time.time)* jumpForce; // perfect semi-circumference arc
				if(Mathf.Sin (-180f+2f*Time.time)<0) // finished the semi-circumference arc
				{
					onJump = false;
				}
			}
		}
		
		// Apply transform
		moveDirection.y -= gravity * Time.deltaTime;
		cc.Move(moveDirection * Time.deltaTime);
		
	}

	void OnControllerColliderHit(ControllerColliderHit hit){

		switch (hit.transform.tag) {
			case "Floor":
				onJump = false;
				break;
			case "Enemy":
				Debug.Log (string.Format("Got hit by {0}", hit.transform.name));
				hitSound.Play();
				break;
		
			default: // Any other object gets pushed away
				/*

				Rigidbody body = hit.collider.attachedRigidbody;
				if (body == null || body.isKinematic)
					return;
				
				if (hit.moveDirection.y < -0.3F)
					return;

				Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
				body.velocity = pushDir * pushPower;


				*/
				break;
		}
	}

	
}