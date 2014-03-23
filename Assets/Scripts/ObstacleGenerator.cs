using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour
{

	// hostile 0-4
	// neutral 5-8
	// powerups 9-INFINITY
	public GameObject[] props;

	public Transform player;

	public Vector2 timeOffset;
	private float counter;

	void Start()
	{
		counter = Random.Range(timeOffset.x,timeOffset.y);
	}

	void Update()
	{
		counter -= Time.deltaTime;
		if(counter<=0){

			// Random prefab
			int i = Random.Range(0, props.Length);
			GameObject go = Instantiate(props[i]) as GameObject;
			go.transform.parent = transform;
			go.transform.position = player.position;

			counter = Random.Range(timeOffset.x,timeOffset.y);
		}
	}
}