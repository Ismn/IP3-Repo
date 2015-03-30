using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{

	public GameObject magnus;
	public GameObject fergus;
	public GameObject textbox;
	public GameObject arrow;
	public Text messageToPlayer;
	public Text messageToPlayer2;
	public Component messages;
	public tutorialStages currentStage;
	int tutorialPart;
	int currentConvo;
	public GameObject refToGameplayScript;
	public bool showArrow = false;
	public bool tutBuildingBuilt;

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
		currentStage = tutorialStages.WADS;
		arrow.SetActive (false);
		messageToPlayer = GetComponent<Text> ();
		tutorialPart = 0;
		currentConvo = 0;
	 
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (tutorialPart) {
		case 0:
			//do shit
			BeginTutorial ();
			currentStage = tutorialStages.WADS;
			//tutorialPart++;
			break;
		case 1:
			//do shots
			if(refToGameplayScript.GetComponent<gamePlayScript>().truckIsSelected)
			{
			currentStage = tutorialStages.truckSelected;
			tutorialPart++;
			}
			break;
		case 2:
			//get fucked
			if(refToGameplayScript.GetComponent<gamePlayScript>().tutMealGave==true)
			{
			currentStage = tutorialStages.giveMeal;
			tutorialPart++;
			}
			break;
		case 3:
			//die
			//#sweetlife
			//#yolo
			if(tutBuildingBuilt)
			{
			currentStage = tutorialStages.buildBuilding;
			tutorialPart++;
			}
			break;
		}
	}
	public void BeginTutorial ()
	{
		if (Application.loadedLevelName == "MAINSCENEFINAL") {
			Debug.Log ("Tutorial Begun");
			switch(currentConvo){
			case 0:
				magnus.SetActive (true);
				messageToPlayer.text = "Hi there! Welcome to Bosnia! My name is Magnus MacFarlane-Barrow, and I'm ready to deliver some of these amazing food supplies to the kids in Bosnia! Luckily, I've got some help from you and my brother Fergus!".ToString ();
				break;
			case 1:
				magnus.SetActive (false);
				fergus.SetActive (true);
				messageToPlayer.text = "Hi I'm Fergus! For some reason I'm grumpier than the other version of me! We're really glad to have you working with us!";
				break;
			case 2:
				magnus.SetActive (true);
				fergus.SetActive (false);
				messageToPlayer.text = "Too right! Okay first of all, let's go over the basics! Use WASD to move your camera all over the scene! Go Up, Down, Left, Right!";
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
				messageToPlayer.text = "Just click on the truck, and then click on the nodes hightlighted throughout the roads to move and then finally click on the school. When you're ready, click go!";
				break;
			case 6:
				magnus.SetActive (true);
				fergus.SetActive (false);
				messageToPlayer.text = "Amazing! We made it to the school! All we have to do now, is give those meals to the kids! Just click on the Give meals button of the left!";
				break;
			case 7:
				magnus.SetActive (false);
				fergus.SetActive (true);
				messageToPlayer.text = "This is incredible, we've really helped these kids in a dire situation!";
				break;
			case 8:
				magnus.SetActive (true);
				fergus.SetActive (false);
				messageToPlayer.text = "Look! Already people have heard about our good deeds! We've raised our awareness to ONE! Now people are donating to us monthly!";
				break;
			case 9:
				magnus.SetActive (true);
				fergus.SetActive (false);
				messageToPlayer.text = "Looks like we're all done here! Let's move on to the next level! [END OF TUTORIAL LEVEL\nNext to Continue!]";
				break;
			case 10:
				Application.LoadLevel("LevelOneAfrica!");
				break;
			}
		}
		if (Application.loadedLevelName == "LevelOneAfrica!") {
			Debug.Log ("Tutorial Begun");
			switch(currentConvo){
			case 0:
		magnus.SetActive (true);
		fergus.SetActive(false);
		messageToPlayer.text = "It was Ten Year Later in 2002 before we fully established our Scottish International Relief venture and lovingly renamed it to MARY'S MEALS! There we had to learn how to create a regular food supply for hungry school children!";
				break;
			case 1:
				magnus.SetActive (true);
				fergus.SetActive(false);
				messageToPlayer.text = "We used trucks to deliver our food, but to cater the food we need a kitchen. Each kitchen costs Ten Coins! To build a kitchen, click on the build tool, and then on a construction site!";
				break;
			}
		}
	}

	public void nextButton()
	{
		currentConvo++;
	}
}
