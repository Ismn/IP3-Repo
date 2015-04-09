using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
	//references to objects in inspector
	public GameObject magnus;
	public GameObject fergus;
	public GameObject textbox;
	public GameObject arrow;
	public GameObject levelCompleted;
	public GameObject showMeal;
	public GameObject showAwareness;
	public GameObject showMoney;
	public GameObject showTime;
	public GameObject showScore;
	public GameObject continueButton;
	public GameObject next;
	//Misc
	public GameObject birds;
	//reference to gameplay script
	public GameObject refToGameplayScript;

	// the text for the tutorial textbox
	public Text messageToPlayer;
	public Text messageToPlayer2;

	// tracks where the player is in the tutorial
	public tutorialStages currentStage;
	int tutorialPart;
	int currentConvo;

	//booleans for tutorial gameplay
	public bool showArrow = false;
	public bool tutBuildingBuilt;

	// Game Info
	public gameInfoScript _GameInfoScript;

	public enum tutorialStages
	{
		WADS,
		giveMeal,
		buildBuilding,
		truckSelected
	}

	// Use this for initialization
	void Start ()
	{
		Assign ();
		currentStage = tutorialStages.WADS;
		arrow.SetActive (false);
		messageToPlayer = GetComponent<Text> ();
		tutorialPart = 0;
		currentConvo = 0;
		showScore.SetActive (false);
		showMoney.SetActive (false);
		showMeal.SetActive (false);
		showTime.SetActive (false);
		showAwareness.SetActive (false);
		continueButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Application.loadedLevelName == "LevelOneAfrica!") {

			if (currentConvo >= 4) {
				magnus.SetActive (false);
				fergus.SetActive (false);
				textbox.SetActive (false);
				messageToPlayer.text = "";
				next.SetActive (false);

			}
		}

		switch (tutorialPart) {
		case 0:
			BeginTutorial ();
			currentStage = tutorialStages.WADS;
			//tutorialPart++;
			break;
		case 1:
			if (refToGameplayScript.GetComponent<gamePlayScript> ().truckIsSelected) {
				currentStage = tutorialStages.truckSelected;
				tutorialPart++;
			}
			break;
		case 2:
			if (refToGameplayScript.GetComponent<gamePlayScript> ().tutMealGave == true) {
				currentStage = tutorialStages.giveMeal;
				tutorialPart++;
			}
			break;
		case 3:
			if (tutBuildingBuilt) {
				currentStage = tutorialStages.buildBuilding;
				tutorialPart++;
			}
			break;
		}
	}

	// this is the tutorial conversation function
	// there is a button below that increments the currentConvo variable to advance the tutorial text
	public void BeginTutorial ()
	{
		if (Application.loadedLevelName == "MAINSCENEFINAL") {

			switch (currentConvo) {
			case 0:
				magnus.SetActive (true);
				messageToPlayer.text = "Hello there! Welcome to Bosnia! My name is Magnus MacFarlane-Barrow, and I'm ready to deliver some of these amazing food supplies to the kids in Bosnia! Luckily, I've got some help from you and my brother Fergus!".ToString ();
				break;
			case 1:
				magnus.SetActive (false);
				fergus.SetActive (true);
				messageToPlayer.text = "Hi I'm Fergus! We're really glad to have you working with us! It's certainly a huge task ahead of us!";
				break;
			case 2:
				magnus.SetActive (true);
				fergus.SetActive (false);
				messageToPlayer.text = "Okay, first of all, let's go over the basics! Use WASD to move your camera across the scene! Up, Down, Left, Right!";
				break;
			case 3:
				magnus.SetActive (false);
				fergus.SetActive (true);
				messageToPlayer.text = "Well done! That helps us see the area around us! Next we'll need to learn how to move our trucks to those needy kids all over Bosnia!";
				break;
			case 4:
				magnus.SetActive (true);
				fergus.SetActive (false);
				arrow.SetActive (true);
				messageToPlayer.text = "If we look at the top of the screen now, (our blue mug) we see we have one set of meals available to feed to needy kids! These meals are already loaded onto our truck!";
				break;
			case 5:
				magnus.SetActive (false);
				fergus.SetActive (true);
				arrow.SetActive (false);
				messageToPlayer.text = "Just click on the truck, and then click on the unfilled cups highlighted throughout the roads to move and then finally click on the school you wish to deliver to. When you're ready, click go!";
				break;
			case 6:
				magnus.SetActive (true);
				fergus.SetActive (false);
				messageToPlayer.text = "Amazing! We made it to the school! All we have to do now is give those meals to the kids! Just click on the Give meals button on the left!";
				break;
			case 7:
				magnus.SetActive (false);
				fergus.SetActive (true);
				messageToPlayer.text = "This is incredible, we've really helped these kids in a dire situation!";
				break;
			case 8:
				magnus.SetActive (true);
				fergus.SetActive (false);
				messageToPlayer.text = "Look! Already people have heard about our good deeds! We've raised our awareness to ONE! Now more people are donating to us!";
				break;
			case 9:
				magnus.SetActive (true);
				fergus.SetActive (false);
				messageToPlayer.text = "And don't forget you can donate anytime too! Just pause the game (top right) and click on the donate button! (Green Pound sign)";
				break;
			case 10:
				levelCompleted.SetActive (true);
				showScore.SetActive (true);
				showMoney.SetActive (true);
				showMeal.SetActive (true);
				showTime.SetActive (true);
				showAwareness.SetActive (true);
				continueButton.SetActive (true);
				//birds.SetActive(true);
				Time.timeScale = 0;
				break;
			case 11:
				Time.timeScale = 1;
				//Application.LoadLevel ("LevelOneAfrica!");
				//levelOneAfricaPlayedBefore = true;
				//gameInfoScript.levelOneAfricaPlayedBefore = true;
				_GameInfoScript._levelOneAfricaPlayedBefore = true;
				Application.LoadLevel ("MainMenu");
				Debug.Log ("load menu");
				break;
			}
		}

		//second part of tutorial
		if (Application.loadedLevelName == "LevelOneAfrica!") {
			Debug.Log ("Tutorial Begun");
			switch (currentConvo) {
			case 0:
				magnus.SetActive (true);
				fergus.SetActive (false);
				messageToPlayer.text = "It was ten years later in 2002 before we fully established our Scottish International Relief venture and lovingly renamed it to Mary's Meals! There we had to learn how to create a regular food supply for hungry school children!";
				break;
			case 1:
				magnus.SetActive (true);
				fergus.SetActive (false);
				messageToPlayer.text = "We used trucks to deliver our food, but to cater the food we need a kitchen. Each kitchen costs ten coins! To build a kitchen, click on the build tool, and then on a construction site!";
				break;
			case 2: 
				magnus.SetActive (true);
				fergus.SetActive (false);
				messageToPlayer.text = "Well done! Meals can now be bought at the kitchen when you have enough money. Each meal costs three coins.";
				break;
			case 3:
				magnus.SetActive (true);
				fergus.SetActive (false);
				messageToPlayer.text = "Now we have to deliver three sets of meals to the schools in the level! We think you've got it, but if you get stuck at any point, click the pause button and the question mark for help!";
				break;
			}
		}

		if (Application.loadedLevelName == "LevelTwoAfrica!") {

			switch (currentConvo) {
			case 0:
				magnus.SetActive (false);
				fergus.SetActive (false);
				textbox.SetActive(false);
				next.SetActive(false);
				break;
			}
		}
	}

	void Assign ()
	{
		_GameInfoScript = GameObject.FindGameObjectWithTag ("levelCheck").GetComponent<gameInfoScript> ();
	}

	//button used to advance tutorial text
	public void nextButton ()
	{
		Test ();
		currentConvo++;
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test ()
	{
		Debug.Log ("Hello!");
	}
}
