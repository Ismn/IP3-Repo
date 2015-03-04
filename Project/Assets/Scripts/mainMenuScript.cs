using UnityEngine;
using System.Collections;

public class mainMenuScript : MonoBehaviour {

	public GUISkin allUI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown ("escape")) {
			Application.Quit();
				}
	}

	void OnGUI (){
		GUI.skin = allUI;
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 100), "", GUI.skin.GetStyle ("PlayGameButton"))) {
			Application.LoadLevel("Wireframe - Test");
				}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 100), "", GUI.skin.GetStyle ("QuitGameButton"))) {
			Application.Quit ();
		}
		if (GUI.Button (new Rect (Screen.width - 100, 0, 100, 100), "", GUI.skin.GetStyle ("GameAudioButton"))) {
			
		}
		if (GUI.Button (new Rect (Screen.width - 200, 0, 100, 100), "", GUI.skin.GetStyle ("GameMusicButton"))) {
			
		}
		}
}
