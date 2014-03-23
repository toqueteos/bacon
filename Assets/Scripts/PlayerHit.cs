using UnityEngine;
using System.Collections;

public class PlayerHit : MonoBehaviour {

	public AudioSource boo;

	void OnCollisionEnter(Collision collision) {
		GameManager.instance.AddHunger(-0.1f);
		Debug.Log(string.Format("Hit {0}", collision.transform.name));
		boo.Play();
	}
}
