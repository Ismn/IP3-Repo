/*Connors Script. V0.6
 Used for the Primary Gameplay Mechanic Loop and also UI elements*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//this script contains the main gameplay variables and code for the buttons

public class gamePlayScript : MonoBehaviour
{
	//game variables

	public int awareness; 
	public int awarenessRate;
	public int money;
	public int moneyRate;
	public int mealsAvailable;
	public int mealsToProvide;
	public float mealsToProvidePercentage;
	public float timeToCycle;
	public float score;
	public int costOfFood;
	public float time;

	//mouse position variables
	public Vector3 mousePosition;
	public float xMousePosition;
	public float yMousePosition;

	//booleans for game code

	public bool gameIsPaused;
	public bool truckIsSelected = false;
	public bool canBuyMeals = false;
	public bool canUnload;
	public bool buildingBuilt;
	public bool canBuild;
	public bool tutMealBought = false;
	public bool tutMealGave = false;

	//references to objects in the inspector
	public GameObject goButton;
	public GameObject truck;
	public GameObject buildButton;
	public GameObject pauseButton;
	public GameObject unPauseButton;
	public GameObject buyMealButton;
	public GameObject giveMealButton;
	public GameObject TutorialArrow;
	//Pause Menu
	public GameObject pauseMenuPopUp;
	public GameObject unPausePauseMenu;
	public GameObject replayButton;
	public GameObject settingsButton;
	public GameObject quitButton;
	public GameObject helpButton;
	//Settings Menu
	public GameObject settingsPopUpButton;
	public GameObject muteMusicButton;
	public GameObject unmuteMusicButton;
	public GameObject muteSoundEffectsButton;
	public GameObject unmuteSoundEffectsButton;
	public GameObject backToPauseButton;



	//Misc



	//reference to character behaviour script
	public CharacterBehaviour character;

	// Use this for initialization
	void Awake ()
	{
		//start values

		mousePosition = Input.mousePosition;
		timeToCycle = 30.0f;	//Start our time Cycle off.
		StartCoroutine (cycleResources ());	// The cycle of resources repeats itself so it just needs this initial start.
		buildingBuilt = false;
		gameIsPaused = false;
		canUnload = false;
		buildButton.SetActive (false);
		unPauseButton.SetActive (false);
		giveMealButton.SetActive (false);
		goButton.SetActive (false);
		truckIsSelected = false;
		pauseMenuPopUp.SetActive (false);
		unPausePauseMenu.SetActive (false);
		replayButton.SetActive (false);
		settingsButton.SetActive (false);
		quitButton.SetActive (false);


		truck = GameObject.FindGameObjectWithTag ("Character");



		//tutorial starting values
		if (Application.loadedLevelName == "MAINSCENEFINAL") { //TEMPORARY TUTORIAL HELP, PROBABLY SHOULD BE FIXED
			awareness = 0;
			money = 0;
			mealsAvailable = 1;
			StartCoroutine (thenGiveMealTutorial ());

		}

		//main game starting values
		if (Application.loadedLevelName == "LevelOneAfrica!") { //TEMPORARY TUTORIAL HELP, PROBABLY SHOULD BE FIXED
			awareness = 1;
			money = 11;
			mealsAvailable = 0;
			moneyRate += 1;

			
		}

	}
	
	// Update is called once per frame
	public void Update ()
	{

		//updates mouse/touch pos

		xMousePosition = Input.mousePosition.x;
		yMousePosition = Input.mousePosition.y;

		//UpdatesScoreToBeDisplayedAtEnd
		time += Time.deltaTime;
		score = ((awareness * 3) + (money * 2) + (mealsAvailable)) / time;

		//buttons only appear if game isn't paused
		if (gameIsPaused == false) {
			pauseButton.SetActive (true);
			pauseMenuPopUp.SetActive (false);
			unPausePauseMenu.SetActive (false);
			replayButton.SetActive (false);
			settingsButton.SetActive (false);
			quitButton.SetActive (false);


			if (money >= 10) {
				buildButton.SetActive (true);
			} else {
				buildButton.SetActive (false);
			}


			// buy meals button conditions

			if (money >= costOfFood && buildingBuilt == true && canBuyMeals == true) {
				buyMealButton.SetActive (true);
			} else if (money <= costOfFood || canBuyMeals == false || buildingBuilt == false) {
				buyMealButton.SetActive (false);
			}

			// give meals button conditions
			
			if (mealsAvailable >= 1 && canUnload == true) {
				giveMealButton.SetActive (true);
			} else if (mealsAvailable <= 1 || canUnload == false) {
				giveMealButton.SetActive (false);
			}

			// truck go button conditions

			if (truckIsSelected == true) {
				goButton.SetActive (true);
			}
		}

		//turns on un-pause button

		if (gameIsPaused == true) {
			unPauseButton.SetActive (true);
			pauseMenuPopUp.SetActive (true);
			unPausePauseMenu.SetActive (true);
			replayButton.SetActive (true);
			settingsButton.SetActive (true);
			quitButton.SetActive (true);

		}
		
	}

	// This rewards the player with donations after a certain (changeable) period of time.
	IEnumerator cycleResources ()
	{ 
		// Gives the player their new money based upon the current Money Rate
		money = money + moneyRate;
		// Time to wait is based on the timeToCyle, we can upgrade this to change time.
		yield return new WaitForSeconds (timeToCycle);	
		StartCoroutine (cycleResources ());
	}

	//build buildings button

	public void build ()
	{
		awareness += 1;
		moneyRate += 1;
		canBuild = true;
		buildButton.SetActive (false);
	}

	// pause button, turns off all other buttons

	public void pause ()
	{
		gameIsPaused = true;
		Time.timeScale = 0;
		pauseButton.SetActive (false);
		unPauseButton.SetActive (true);
		buildButton.SetActive (false);
		buyMealButton.SetActive (false);
		giveMealButton.SetActive (false);
		goButton.SetActive (false);
		settingsPopUpButton.SetActive (false);
		muteMusicButton.SetActive (false);
		muteSoundEffectsButton.SetActive (false);
		unmuteMusicButton.SetActive (false);
		unmuteSoundEffectsButton.SetActive (false);
		backToPauseButton.SetActive (false);
		helpButton.SetActive (true);
	}

	//un-pause button, turns other buttons back on

	public void unPause ()
	{
		gameIsPaused = false;
		Time.timeScale = 1;
		pauseButton.SetActive (true);
		unPauseButton.SetActive (false);
		buildButton.SetActive (true);
		buyMealButton.SetActive (true);
		giveMealButton.SetActive (true);
		goButton.SetActive (true);
		settingsPopUpButton.SetActive (false);
		muteMusicButton.SetActive (false);
		muteSoundEffectsButton.SetActive (false);
		unmuteMusicButton.SetActive (false);
		unmuteSoundEffectsButton.SetActive (false);
		backToPauseButton.SetActive (false);
		helpButton.SetActive (false);
		
	}

	//buy meals button

	public void buyMeal ()
	{
		mealsAvailable += 1;
		money -= costOfFood;
		tutMealBought = true;
	}

	//give meals button

	public void giveMeal ()
	{
		awareness += 1;
		mealsAvailable -= 1;
		moneyRate += 1;
		tutMealGave = true;
	}

	public void settingsPopUp(){
		settingsPopUpButton.SetActive (true);
		muteMusicButton.SetActive (true);
		muteSoundEffectsButton.SetActive (true);
		backToPauseButton.SetActive (true);
		if (audio.volume == 0.0f) {
			unmuteMusicButton.SetActive (true);
			unmuteSoundEffectsButton.SetActive (true);
		} else {
			unmuteMusicButton.SetActive (false);
			unmuteSoundEffectsButton.SetActive (false);
		}
		unPauseButton.SetActive (false);
		pauseMenuPopUp.SetActive (false);
		unPausePauseMenu.SetActive (false);
		replayButton.SetActive (false);
		settingsButton.SetActive (false);
		quitButton.SetActive (false);
	}
	
	public void replayLevel(){
		if(Application.loadedLevelName==("MAINSCENEFINAL")){
			Application.LoadLevel("MAINSCENEFINAL");
		}
		if(Application.loadedLevelName==("LevelOneAfrica!")){
			Application.LoadLevel("LevelOneAfrica!");
		}
	}

	public void quitGame(){
		Debug.Log ("Quit Game");
		Application.Quit ();
	}

	public void muteMusic(){
		unmuteMusicButton.SetActive (true);
		AudioListener.volume = 0.0f;
	}

	public void unmuteMusic(){
		unmuteMusicButton.SetActive (false);
		AudioListener.volume = 1.0f;
	}

	public void muteSoundEffects(){
		unmuteSoundEffectsButton.SetActive (true);
		AudioListener.volume = 0.0f;
	}

	public void unmuteSoundEffects(){
		unmuteSoundEffectsButton.SetActive (false);
		AudioListener.volume = 1.0f;
	}

	public void goBackToSettings(){
		settingsPopUpButton.SetActive (false);
		muteMusicButton.SetActive (false);
		muteSoundEffectsButton.SetActive (false);
		unmuteMusicButton.SetActive (false);
		unmuteSoundEffectsButton.SetActive (false);
		backToPauseButton.SetActive (false);
	}

	public void openHelp(){
		animation.Play ("openHelp");
	}
	public void closePreviousPause(){
		Time.timeScale = 0;
	}
	//move truck button

	public void moveTruck ()
	{
		truck.GetComponent<CharacterBehaviour> ().canMove = true;
		truck.GetComponent<CharacterBehaviour> ().truckIsSelected = false;
		goButton.SetActive (false);
	}

	public void justStopTime(){//used to fix a small bug with the help menu
		Debug.Log ("Time stopped for help");
		Time.timeScale = 0;
		unPauseButton.SetActive (true);
	}

	//ienumerator for the arrow in the tutorial

	IEnumerator thenGiveMealTutorial ()
	{
		yield return new WaitForSeconds (21.0f);


	}
}