/*Connors Script. V0.01. Last Updated 26/02/15
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
	public int score;
	public int costOfFood;

	//mouse position variables
	public Vector3 mousePosition;
	public float xMousePosition;
	public float yMousePosition;

	//booleans for game code

	public bool gameIsPaused;/
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
		truck = GameObject.FindGameObjectWithTag ("Character");


		//tutorial starting values
		if (Application.loadedLevelName == "MAINSCENEFINAL") { //TEMPORARY TUTORIAL HELP, PROBABLY SHOULD BE FIXED
			awareness = 0;
			money = 0;
			mealsAvailable = 0;
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


		//buttons only appear if game isn't paused
		if (gameIsPaused == false) {
			pauseButton.SetActive (true);

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
	}

	//un-pause button, turns other buttons back on

	public void unPause ()
	{
		gameIsPaused = false;
		Time.timeScale = 1;
		;
		pauseButton.SetActive (true);
		unPauseButton.SetActive (false);
		buildButton.SetActive (true);
		buyMealButton.SetActive (true);
		giveMealButton.SetActive (true);
		goButton.SetActive (true);
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

	//move truck button

	public void moveTruck ()
	{
		truck.GetComponent<CharacterBehaviour> ().canMove = true;
		truck.GetComponent<CharacterBehaviour> ().truckIsSelected = false;
		goButton.SetActive (false);
	}

	//ienumerator for the arrow in the tutorial

	IEnumerator thenGiveMealTutorial ()
	{
		yield return new WaitForSeconds (21.0f);
		mealsAvailable = 1;
		TutorialArrow.SetActive (true);

	}
}