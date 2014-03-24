using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour {

	public Vector3 spawn;
	public bool flicker = true;
	public Vector2 flickerRange;
	static bool swapSide = false;
	static int nameId = 0;

	void Start ()
	{
		name = string.Format("lamptokio{0}", nameId);
		nameId++;
		if (swapSide) {
			spawn.x = -spawn.x;
		}

		swapSide = !swapSide;

		transform.position += spawn;
	}
	
	void Update()
	{

		if (Random.Range(flickerRange.x, flickerRange.y) == 0)
		{
			StartCoroutine("Flicker");
		}
	}

	IEnumerator Flicker() {
		float i = light.intensity;
		yield return new WaitForSeconds(0.5f);
		light.intensity = 0.2f;
		yield return new WaitForSeconds(0.5f);
		light.intensity = 0.5f;
		yield return new WaitForSeconds(0.5f);
		light.intensity = 0.2f;
		yield return new WaitForSeconds(0.5f);
		light.intensity = i;
	}
}
