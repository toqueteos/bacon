using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour
{

	public int change = 30;
	SpriteRenderer sr;
	int counter = 0;

	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
	}
	
	void Update()
	{
		counter = (counter + 1) % change;

		if (counter == 0) {
			Color c = new Color(Random.value, Random.value, Random.value);
			sr.color = c;
		}
	}
}
