﻿using UnityEngine;
using System.Collections;

public class mainMenuScript : MonoBehaviour
{

	public GUISkin allUI;
	public GameObject playButton;
	public GameObject quitButton;
	public GameObject fullBackground;
	public GameObject background;
	public GameObject africaUnlocked;
	public GameObject africaHighlighted;
	public GameObject africaLocked;
	public GameObject asiaUnlocked;
	public GameObject asiaHighlighted;
	public GameObject asiaLocked;
	public GameObject southAmericaUnlocked;
	public GameObject southAmericaHighlighted;
	public GameObject southAmericaLocked;
	public GameObject carribeanUnlocked;
	public GameObject carribeanHighlighted;
	public GameObject carribeanLocked;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("escape")) {
			Application.Quit ();
		}
	}

	void OnGUI ()
	{
		/*GUI.skin = allUI;
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 100), "", GUI.skin.GetStyle ("PlayGameButton"))) {
			Application.LoadLevel ("Wireframe - Test");
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 100), "", GUI.skin.GetStyle ("QuitGameButton"))) {
			Application.Quit ();
		}
		if (GUI.Button (new Rect (Screen.width - 100, 0, 100, 100), "", GUI.skin.GetStyle ("GameAudioButton"))) {

		}
		if (GUI.Button (new Rect (Screen.width - 200, 0, 100, 100), "", GUI.skin.GetStyle ("GameMusicButton"))) {

		}*/
	}
	public void PlayButton ()
	{
		fullBackground.SetActive (false);
		playButton.SetActive (false);
		quitButton.SetActive (false);
		asiaUnlocked.SetActive (true);
		africaLocked.SetActive (true);
		carribeanLocked.SetActive (true);
		southAmericaLocked.SetActive (true);
		background.SetActive (true);

	}

	public void QuitButton ()
	{
		Application.Quit ();
	}

	public void AfricaPlayButton(){
		Application.LoadLevel ("LevelOne");
	}
}
