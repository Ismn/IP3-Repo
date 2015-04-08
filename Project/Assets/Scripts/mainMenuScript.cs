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

	//AsiaLevels
	public GameObject asiaBackground;
	public GameObject asiaLevelOne;
	public GameObject asiaLevelTwo;
	public GameObject asiaLevelThree;
	public GameObject asiaLevelOnePlay;
	public GameObject asiaLevelLocked;
	public GameObject asiaLevelTwoUnlocked;

	//AfricaLevels
	public GameObject africaBackground;
	public GameObject africaLevelOne;
	public GameObject africaLevelTwo;
	public GameObject africaLevelTwoUnlocked;
	public GameObject africaLevelThree;
	public GameObject africaLevelOnePlay;
	public GameObject africaLevelOneBackground;


	//Misc
	public GameObject levelOneBackground;
	public GameObject levelTwoBackground;
	public GameObject levelThreeBackground;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	public gameInfoScript _GameInfoScript;

	// Use this for initialization
	void Start ()
	{
		Assign ();
		if (_GameInfoScript._levelOneAfricaPlayedBefore == true) {
			//africaUnlocked.SetActive (true);
			Debug.Log ("here");
			asiaLevelTwo.SetActive (false);
			asiaLevelTwoUnlocked.SetActive (true);

		}
	}

	void Assign ()
	{
		_GameInfoScript = GameObject.FindGameObjectWithTag ("levelCheck").GetComponent<gameInfoScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("escape")) {
			Application.Quit ();
		}


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

	public void AsiaClick ()
	{
		asiaUnlocked.SetActive (false);
		africaLocked.SetActive (false);
		africaUnlocked.SetActive (false);
		carribeanLocked.SetActive (false);
		southAmericaLocked.SetActive (false);
		background.SetActive (false);
		asiaBackground.SetActive (true);
		asiaLevelOne.SetActive (true);
		if (_GameInfoScript._levelOneAfricaPlayedBefore == false) {
			asiaLevelTwo.SetActive (true);
		}
		asiaLevelThree.SetActive (true);
	}
	public void AfricaClick ()
	{
		asiaUnlocked.SetActive (false);
		africaLocked.SetActive (false);
		africaUnlocked.SetActive (false);
		carribeanLocked.SetActive (false);
		southAmericaLocked.SetActive (false);
		background.SetActive (false);
		africaBackground.SetActive (true);
		africaLevelOne.SetActive (true);
		if (gameInfoScript.levelOneAfricaPlayedBefore == true) {
			africaLevelTwoUnlocked.SetActive (true);
		} else if (gameInfoScript.levelOneAfricaPlayedBefore == false) {
			africaLevelTwo.SetActive (true);
		}
		africaLevelThree.SetActive (true);
	}
	public void AsiaLevelOne ()
	{
		asiaBackground.SetActive (false);
		asiaLevelOne.SetActive (false);

		asiaLevelTwo.SetActive (false);
		asiaLevelThree.SetActive (false);
		levelOneBackground.SetActive (true);
		asiaLevelOnePlay.SetActive (true);

	
	}

	public void AfricaLevelOne ()
	{
		africaBackground.SetActive (false);
		africaLevelOne.SetActive (false);
		africaLevelTwo.SetActive (false);
		africaLevelThree.SetActive (false);
		africaLevelOneBackground.SetActive (true);
		africaLevelOnePlay.SetActive (true);
		
		
	}

	public void QuitButton ()
	{
		Application.Quit ();
	}

	public void AsiaPlayLevel1Button ()
	{
		Application.LoadLevel ("MAINSCENEFINAL");
	}

	public void AfricaPlayLevel1Button ()
	{
		Application.LoadLevel ("LevelOneAfrica!");
	}
}
