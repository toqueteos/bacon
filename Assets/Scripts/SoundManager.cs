using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

	[Range(0.00f, 1.00f)]
	public float volume = 1;
	public AudioSource startTrack;
	public bool playOnStart = false;
	public AudioSource[] bgms;
	bool play = false;
	AudioSource current = null;
	float currentVolume;

	void Start()
	{
		bgms = GetComponentsInChildren<AudioSource>();
		currentVolume = volume;

		if (startTrack != null) {
			current = startTrack;
			current.Play();
			play = true;
		}
	}
	
	void Update()
	{
		if (current != null && volume != currentVolume)
		{
			currentVolume = volume;
			current.volume = volume;
		}

		Toggle(0, KeyCode.Alpha1);
		Toggle(1, KeyCode.Alpha2);
	}

	void Toggle(int index, KeyCode key) {
		if (Input.GetKeyDown(key)) {
			if (!play) {
				if (current != null) {
					current.Stop();
				}
				current = bgms[index];
				current.Play();
			} else {
				current.Stop();
			}
		}
	}
}
