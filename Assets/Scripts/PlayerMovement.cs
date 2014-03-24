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
	
	public Vector3 moveDirection = Vector3.zero;
	private Vector3 moveInertia = Vector3.zero;
	
	public AudioSource jumpSound;
	
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
		bool jump = Input.GetKey(KeyCode.Space);
		
		// Default rotation (facing camera)
		float rotx = defRotation.eulerAngles.x;
		float roty = defRotation.eulerAngles.y;
		float rotz = defRotation.eulerAngles.z;
		
		// We reset rotation first (if triggered)
		if (elmove || ermove)
		{
			roty = 0f;
		}
		
		anim.SetBool("FrontJump", true);
		if (slmove || srmove)
		{
			anim.SetBool("FrontJump", false);
		}
		
		// Then we can aply the animation and a new rotation
		if (lmove)
		{
			roty = lateralRotation;
			if (!anim.GetCurrentAnimatorStateInfo(0).IsName("LeftJump"))
			{
				anim.SetTrigger("LeftJump");
			}
		}
		if (rmove)
		{
			roty = -lateralRotation;
			if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RightJump"))
			{
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
			}
		}
		else // JUMPING!
		{
			moveDirection.y = Mathf.Sin (-180f+2f*Time.time)* jumpForce;
		}
		
		// Apply transform
		moveDirection.y -= gravity * Time.deltaTime;
		cc.Move(moveDirection * Time.deltaTime);
		
	}
}