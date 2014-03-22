using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	CharacterController cc;
	public Vector3 speed = Vector3.forward;

	void Start()
	{
		cc = GetComponent<CharacterController>();
		if (cc == null)
		{
			Debug.LogError("CharacterController component is missing.");
		}
	}
	
	void Update()
	{
		cc.SimpleMove(-speed);
	}
}
