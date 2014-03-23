using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour
{

	public int change = 30;
	SpriteRenderer sr;
	Animator anim;
	int counter = 0;

	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		if (sr == null)
		{
			Debug.LogError("SpriteRenderer component is missing.");
		}

		anim = GetComponent<Animator>();
		if (anim == null)
		{
			Debug.LogError("Animator component is missing.");
		}
	}
	
	void Update()
	{
		counter = (counter + 1) % change;

		if (counter == 0)
		{
			Color c = new Color(Random.value, Random.value, Random.value);
			sr.color = c;
		}
	}

	void OnEnable()
	{
		anim = GetComponent<Animator>();
		if (anim == null)
		{
			Debug.LogError("Animator component is missing.");
		}
	}

	void OnDisable()
	{
		anim.speed = 1f;
	}

	public void SetAnimationSpeed(float s) {
		anim.speed = s;
	}
}
