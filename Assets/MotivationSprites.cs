using UnityEngine;
using System.Collections;

public class MotivationSprites : MonoBehaviour
{

	public UI2DSprite uiSprite;
	public Sprite[] sprites;
	public Vector3 hidePosition;
	public Vector3 showPosition;
	EnemyGenerator eg;
	public int showEvery = 5;
	public float fadeAfter = 2f;
	public float tweenDuration = 1f;
	float counter = 0;

	void Start()
	{
		if (uiSprite == null) {
			Debug.LogError("UI2DSprite component is missing.");
		}
		if (sprites == null) {
			Debug.LogError("sprites array has size 0.");
		}

		eg = GetComponent<EnemyGenerator>();
		if (eg == null) {
			Debug.LogError("EnemyGenerator component is missing.");
		}
	}
	
	void Update()
	{
		GameObject go = uiSprite.gameObject;

		if (eg.numPropsSpawned > 0 && (eg.numPropsSpawned % showEvery) == 0) {
			int index = Random.Range(0, sprites.Length);
			uiSprite.sprite2D = sprites[index];

			TweenPosition.Begin(go, tweenDuration, showPosition);
			TweenAlpha.Begin(go, tweenDuration, 1f);
		}

		counter -= Time.deltaTime;

		if (counter <= 0) {
			TweenPosition.Begin(go, tweenDuration, hidePosition);
			TweenAlpha.Begin(go, tweenDuration, 0f);

			counter = fadeAfter;
		}
	}
}
