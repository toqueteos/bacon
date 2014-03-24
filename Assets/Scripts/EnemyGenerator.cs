using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour
{

	public int numPropsSpawned = 0;
	public GameObject[] props;
	public Transform player;
	public Vector2 timeOffset;
	private float counter;

	void Start()
	{
		counter = Random.Range(timeOffset.x, timeOffset.y);
	}

	void Update()
	{
		if(props.Length>0)
		{
			counter -= Time.deltaTime;

			if (counter <= 0)
			{
				// Random prefab
				int i = Random.Range(0, props.Length);
				GameObject go = Instantiate(props [i]) as GameObject;
				go.transform.parent = transform;
				go.transform.position = player.position;

				FadeDestroy fd = go.GetComponent<FadeDestroy>();
				fd.player = player;

				counter = Random.Range(timeOffset.x, timeOffset.y);

				numPropsSpawned++;
			}
		}
	}
}