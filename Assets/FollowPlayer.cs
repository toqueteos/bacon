using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{

	public Transform player;

	void Update()
	{
		transform.position = player.position;
	}
}
