using UnityEngine;
using System.Collections;

public class DishCreator : MonoBehaviour {

	public GameObject[] props;

	FadeDestroy fd;
	FadeDestroy fdd;
	static int nameId = 0;
	
	void Start()
	{
		fd = GetComponent<FadeDestroy>();
		name = string.Format("dish{0}", nameId);
		nameId++;	
		
		Vector3 pos = fd.player.position;

		pos.z -= 15f;
		pos.y = 0.2f;
		pos.x = Random.Range(-4f,4f);

		transform.position = pos;

		Vector3 pp = Vector3.zero;
		// 2 random foods over the dish
		for (int i = 0; i < 2; i++) {
			int j = Random.Range(0, props.Length);
			GameObject go = Instantiate(props [j]) as GameObject;

			pp.x = pos.x + Random.Range(-1f,1f);
			pp.y = pos.y + 2.5f * i + Random.Range(4f,8f);
			pp.z = pos.z + Random.Range(-1f,1f);
			go.transform.position = pp;

			// Slightly rotate fork sideways
			float rot = Random.Range(0f, 359f);
			go.transform.rotation = Quaternion.Euler(0, rot, 0);

			FadeDestroy fdd = go.GetComponent<FadeDestroy>();
			fdd.player = fd.player;

		}
	}

}
