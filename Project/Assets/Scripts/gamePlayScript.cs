/*Connors Script. V0.01. Last Updated 26/02/15
 Used for the Primary Gameplay Mechanic Loop and also UI elements*/
using UnityEngine;
using System.Collections;

public class gamePlayScript : MonoBehaviour {

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
	public Vector3 mousePosition;
	public GUISkin allUI;//Assigns the GUI skin to use, DO NOT ALTER FROM "allUI";
	public float xMousePosition;
	public float yMousePosition;
	public bool gameIsPaused;//Determines whether the game is in a pause state.
	public int costOfFood;


	// Use this for initialization
	void Start () 
    {
        mousePosition = Input.mousePosition;
		timeToCycle = 5.0f; //Start our time Cycle off.
		StartCoroutine(cycleResources ()); //The cycle of resources repeats itself so it just needs this initial start.
		buildingBuilt = false;
		gameIsPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		xMousePosition = Input.mousePosition.x;
		yMousePosition = Input.mousePosition.y;

		if (Input.GetKeyDown ("escape")) {
			Application.Quit ();
				}
	}

	IEnumerator cycleResources(){ //This rewards the player with donations after a certain (changeable) period of time.
		money = money + moneyRate; // Gives the player their new money based upon the current Money Rate
		Debug.Log ("Money given");
		Debug.Log ("Should be waiting time until next cycle of Donations");
		yield return new WaitForSeconds (timeToCycle); //Time to wait is based on the timeToCyle, we can upgrade this to change time.
		StartCoroutine (cycleResources ());
		Debug.Log ("New Cycle has Begun");


		}

	void OnGUI(){
				GUI.skin = allUI;
				GUI.Box (new Rect (0, 0, 200, 50), "");
				GUI.Box (new Rect (20, 5, 20, 20), "", GUI.skin.GetStyle ("AwarenessIcon"));
		GUI.Label (new Rect (40, 5, 20, 20), awareness.ToString ("F0"));//Displays awareness as a string (it is rounded to have NO Decimel place)
		GUI.Box (new Rect (80, 5, 20, 20), "", GUI.skin.GetStyle ("MoneyIcon"));
		GUI.Label (new Rect (100, 5, 20, 20), money.ToString ("F0"));//Displays money available as a string (it is rounded to have NO Decimel place)
		GUI.Box (new Rect (140, 5, 20, 20), "", GUI.skin.GetStyle ("MealsAvailableIcon"));
				GUI.Label (new Rect (160, 5, 20, 20), mealsAvailable.ToString ("F0"));//Displays meals available to distribute as a string (it is rounded to have NO Decimel place)
				GUI.Label (new Rect (xMousePosition, yMousePosition, 100, 100), GUI.tooltip);//Keeps the ToolTip on the Mouse's Position
				if (money >= 10) {
						if (GUI.Button (new Rect (400, 400, 100, 100), new GUIContent ("Build a Building", "Click here to construct a building"), GUI.skin.GetStyle ("Construction"))) {
								new GUIContent (GUI.tooltip = "Click here to construct a building");
								awareness += 2;
								money -= 10;
								buildingBuilt = true;
						}
				}
				if (buildingBuilt == true) {
						if (money >= costOfFood) {
								if (GUI.Button (new Rect (520, 400, 100, 100), "Buy Meals", GUI.skin.GetStyle("BuyButton"))) {
										mealsAvailable += 1;
										money -= costOfFood;
								}
						}
						if (mealsAvailable >= 1) {
								if (GUI.Button (new Rect (640, 400, 100, 100), "Give Meals", GUI.skin.GetStyle("SellButton"))) {
										awareness += 1;
										mealsAvailable -= 1;
										moneyRate+=1;
								}
						}
				}
				if (gameIsPaused == false) {
						if (GUI.Button (new Rect (Screen.width - 100, 0, 100, 100), "", GUI.skin.GetStyle ("PauseButton"))) {
								gameIsPaused = true;
								Time.timeScale = 0;
								Debug.Log ("Game is Paused");
						}
				}
				if (gameIsPaused == true) {
						if (GUI.Button (new Rect (Screen.width - 100, 0, 100, 100), "", GUI.skin.GetStyle ("PlayButton"))) {
								Time.timeScale = 1;
								gameIsPaused = false;
								Debug.Log ("Game is Playing");
						}
				}
		}
}
