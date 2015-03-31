using UnityEngine;
using System.Collections;

public class audioScript : MonoBehaviour {

	public AudioClip track1;
	public AudioClip track2;

	// Use this for initialization
	void Start () {
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Application.loadedLevelName != ("MainMenu")) {
			audio.loop = false;
			if(audio.isPlaying!=true){
				audio.clip = track2;
				audio.Play();
			}

		}*/
		GameObject.DontDestroyOnLoad (gameObject);
	}

	IEnumerator CycleAudio(){
		yield return new WaitForSeconds (track1.length);
		audio.clip = track2;
		audio.Play();
		yield return new WaitForSeconds (track2.length);
		audio.clip = track1;
		audio.Play ();
		CycleAudio ();
	}
}
