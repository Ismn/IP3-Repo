/*Connors Script. V0.01. Last Updated 26/02/15
 Used for the Primary Gameplay Mechanic Loop and also UI elements*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gamePlayScript : MonoBehaviour
{
	public int awareness; //This is the value shown for awareness.
	public int awarenessRate; //This value can be used if we want to increment awareness by varying amounts.
	public int money; //This is the value shown for money.
	public int moneyRate;//This value can be used if we want to increment money by varyng amounts.
	public int mealsAvailable;//This is the number of meals we have available to distribute. 
	public int mealsToProvide;//This is the number of meals we should provide in a level.
	public float mealsToProvidePercentage;//This is the number of meals we are providing out of the amount we have to in order to complete the level.
	public float timeToCycle;//This is the changeable time that it takes for donations to arrive.
	public int score;//This is the current level score.
	public bool buildingBuilt;//This is simply used for testing.
	public bool canBuild;
	public Vector3 mousePosition;
	public GUISkin allUI;//Assigns the GUI skin to use, DO NOT ALTER FROM "allUI";
	public float xMousePosition;
	public float yMousePosition;
	public bool gameIsPaused;//Determines whether the game is in a pause state.
	public int costOfFood;
	public bool truckIsSelected = false;
	public bool canHasBuyMeals = false;

	public GameObject truck;
	public bool canUnload;
	public bool dropOff;
	public GameObject buildButton;
	public GameObject pauseButton;
	public GameObject unPauseButton;
	public GameObject buyMealButton;
	public GameObject giveMealButton;
	public GameObject goButton;

	public CharacterBehaviour character;

	// Use this for initialization
	void Awake ()
	{
		mousePosition = Input.mousePosition;
		timeToCycle = 5.0f;	//Start our time Cycle off.
		StartCoroutine (cycleResources ());	// The cycle of resources repeats itself so it just needs this initial start.
		buildingBuilt = false;
		gameIsPaused = false;
		canUnload = false;
		dropOff = false;
		buildButton.SetActive (false);
		unPauseButton.SetActive (false);
		giveMealButton.SetActive (false);
		goButton.SetActive (false);
		truckIsSelected = false;
		truck = GameObject.FindGameObjectWithTag ("Character");
	}
	
	// Update is called once per frame
	public void Update ()
	{
		xMousePosition = Input.mousePosition.x;
		yMousePosition = Input.mousePosition.y;

		if (gameIsPaused == false) {
			pauseButton.SetActive (true);
		}

		if (gameIsPaused == true) {
			unPauseButton.SetActive (true);
		}

		if (gameIsPaused == false) {
			if (money >= 10) {
				buildButton.SetActive (true);
				Debug.Log ("Enough Money to Build");
			} else {
				buildButton.SetActive (false);
			}

			if (money >= costOfFood && buildingBuilt == true && canHasBuyMeals == true) {
				buyMealButton.SetActive (true);
			} else if (money <= costOfFood || canHasBuyMeals == false || buildingBuilt == false) {
				buyMealButton.SetActive (false);
			}

			if (mealsAvailable >= 1 && canUnload == true && dropOff == true) {
				giveMealButton.SetActive (true);
			} else if (mealsAvailable <= 1 || canUnload == false || dropOff == false) {
				giveMealButton.SetActive (false);
			}

			if (truckIsSelected == true) {
				goButton.SetActive (true);
			}
		}

		if (Input.GetKeyDown ("escape")) {
			Application.Quit ();
		}

		OnGUI ();	
	}

	// This rewards the player with donations after a certain (changeable) period of time.
	IEnumerator cycleResources ()
	{ 
		money = money + moneyRate;	// Gives the player their new money based upon the current Money Rate
		Debug.Log ("Money given");
		Debug.Log ("Should be waiting time until next cycle of Donations");
		yield return new WaitForSeconds (timeToCycle);	// Time to wait is based on the timeToCyle, we can upgrade this to change time.
		StartCoroutine (cycleResources ());
		Debug.Log ("New Cycle has Begun");
	}

	void OnGUI ()
	{

	}

	public void build ()
	{
		awareness += 2;
		canBuild = true;
		buildButton.SetActive (false);
	}

	public void pause ()
	{
		gameIsPaused = true;
		Time.timeScale = 0;
		Debug.Log ("Game is Paused");
		pauseButton.SetActive (false);
		unPauseButton.SetActive (true);
		buildButton.SetActive (false);
		buyMealButton.SetActive (false);
		giveMealButton.SetActive (false);
	}

	public void unPause ()
	{
		gameIsPaused = false;
		Time.timeScale = 1;
		Debug.Log ("Game is unPaused");
		pauseButton.SetActive (true);
		unPauseButton.SetActive (false);
		buildButton.SetActive (true);
		buyMealButton.SetActive (true);
		giveMealButton.SetActive (true);
	}

	public void buyMeal ()
	{
		mealsAvailable += 1;
		money -= costOfFood;
	}

	public void giveMeal ()
	{
		awareness += 1;
		mealsAvailable -= 1;
		moneyRate += 1;
	}

	public void moveTruck ()
	{
		Debug.Log ("gobuttonclick");
		truck.GetComponent<CharacterBehaviour> ().canMove = true;
		//truckIsSelected = false;
	}
}