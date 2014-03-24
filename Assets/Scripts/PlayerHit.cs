using UnityEngine;
using System.Collections;

public class PlayerHit : MonoBehaviour
{
	public AudioSource hitSound;

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.transform.tag == "Enemy")
		{
			Debug.Log(string.Format("Got hit by {0}", hit.transform.name));
						
			// Enemies are ignored for collisions once hit
			hit.transform.tag = "Untagged";
						
			// Gameplay response
			GameManager.instance.AddHunger(-0.1f);
			hitSound.Play();
		}
	}
}