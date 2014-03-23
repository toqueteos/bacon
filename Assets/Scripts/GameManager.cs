using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;
	public UIProgressBar hunger;
	public float fillRate = 0.05f;
	public float hurryUpStart = 0.75f;
	public float hurryUpAnimationSpeed = 3.5f;
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

	void Update() {
		AddHunger(fillRate * Time.deltaTime);
	}
	
	public void AddHunger(float h) {
		hunger.value = Mathf.Clamp(hunger.value + h, 0f, 1f);

		bool hurry = hunger.value >= hurryUpStart;

		flashyBackground.enabled = hurry;

		if (hurry) {
			flashyBackground.SetAnimationSpeed(hurryUpAnimationSpeed);
		}
	}
}
