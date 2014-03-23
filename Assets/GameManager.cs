using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;
	public UIProgressBar hunger;
	public float hurryUpStart = 0.75f;
	bool hurryUp = false;
	public ColorChanger flashyBackground;

	void Start()
	{
		instance = this;

		if (hunger == null) {
			Debug.LogError("UIProgressBar component is missing.");
		}

		if (flashyBackground == null) {
			Debug.LogError("ColorChanger component is missing.");
		}
	}
	
	public void AddHunger(float h) {
		hunger.value = h;

		bool hurry = hunger.value >= hurryUpStart;

		hurryUp = hurry;
		flashyBackground.enabled = hurry;
	}
}
