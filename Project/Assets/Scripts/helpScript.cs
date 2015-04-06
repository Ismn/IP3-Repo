using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class helpScript : MonoBehaviour {
	//Messages
	public Text helpMessage;
	public int helpMessageNumber;
	public Text clickToLearnMessage;
	//Help Symbols
	public GameObject awareness;
	public GameObject currency;
	public GameObject meals;
	public GameObject build;
	public GameObject buy;
	public GameObject give;
	public GameObject music;
	public GameObject soundeffect;
	public GameObject donation;
	public GameObject pause;
	public GameObject play;
	public GameObject exit;
	public GameObject upgrade;
	public GameObject truck;
	public GameObject go;
	//Help buttons
	public GameObject awarenessButton;
	public GameObject currencyButton;
	public GameObject mealButton;
	public GameObject buildButton;
	public GameObject buyButton;
	public GameObject giveButton;
	public GameObject musicButton;
	public GameObject soundeffectButton;
	public GameObject donationButton;
	public GameObject pauseButton;
	public GameObject playButton;
	public GameObject exitButton;
	public GameObject upgradeButton;
	public GameObject truckButton;
	public GameObject goButton;
	public GameObject helpMenuBackground;
	public GameObject exitHelpButton;






	// Use this for initialization
	void Start () {
		helpMessageNumber = 16;
		helpMessage = GetComponent<Text>();
		clickToLearnMessage = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	switch (helpMessageNumber) {
		case 0:
			helpMessage.text = "Click a button on the left to have its help and information listed here!";
			break;
		case 1:
			helpMessage.text = "This is the AWARENESS symbol, this represents how well the charity is known throughout the world." +
				" The player can increase this number by building new structures, delivering meals to kids, delivering to more schools" +
					" and by posting about Mary's Meals to numerous Social Media sites.";
			awareness.SetActive(true);
			currency.SetActive(false);
			meals.SetActive(false);
			build.SetActive(false);
			buy.SetActive(false);
			give.SetActive(false);
			music.SetActive(false);
			soundeffect.SetActive(false);
			donation.SetActive(false);
			pause.SetActive(false);
			play.SetActive(false);
			exit.SetActive(false);
			upgrade.SetActive(false);
			truck.SetActive(false);
			go.SetActive(false);

			break;
		case 2:
			helpMessage.text = "This is the CURRENCY symbol, this represents how much money you have at your disposal. You can use this money to" +
				"construct new buildings, buy and maintain vehicles, acquire new meals and also for upgrades! The higher your awareness is," +
				"the more money is donated to the charity every couple of seconds!";
			awareness.SetActive(false);
			currency.SetActive(true);
			meals.SetActive(false);
			build.SetActive(false);
			buy.SetActive(false);
			give.SetActive(false);
			music.SetActive(false);
			soundeffect.SetActive(false);
			donation.SetActive(false);
			pause.SetActive(false);
			play.SetActive(false);
			exit.SetActive(false);
			upgrade.SetActive(false);
			truck.SetActive(false);
			go.SetActive(false);
			break;
		case 3:
			helpMessage.text = "This is the MEALS symbol, this represents how many meals you have available at your kitchens! You can buy" +
				"new meals from market places, and prepare them at kitchens! You can then deliver these meals to needy school kids at their" +
				"place of education! Delivering meals is one way to increase AWARENESS!";
			awareness.SetActive(false);
			currency.SetActive(false);
			meals.SetActive(true);
			build.SetActive(false);
			buy.SetActive(false);
			give.SetActive(false);
			music.SetActive(false);
			soundeffect.SetActive(false);
			donation.SetActive(false);
			pause.SetActive(false);
			play.SetActive(false);
			exit.SetActive(false);
			upgrade.SetActive(false);
			truck.SetActive(false);
			go.SetActive(false);
			break;
		case 4:
			helpMessage.text = "This it the BUILD symbol, this is used ti construct various buildings around the levels. Building a " +
				"structure will grand benefits specific to that structure, e.g. by constructing a kitchen you can prepre more meals" +
				"and gain access to more trucks!";
			awareness.SetActive(false);
			currency.SetActive(false);
			meals.SetActive(false);
			build.SetActive(true);
			buy.SetActive(false);
			give.SetActive(false);
			music.SetActive(false);
			soundeffect.SetActive(false);
			donation.SetActive(false);
			pause.SetActive(false);
			play.SetActive(false);
			exit.SetActive(false);
			upgrade.SetActive(false);
			truck.SetActive(false);
			go.SetActive(false);
			break;
		case 5:
			helpMessage.text = "This is the BUY symbol, clicking this will purchase a new meal that will be prepared and made available" +
				"at one of your kitchens. You will always need to continually purchase meals in order to feed the various school" +
				"children around the level!";
			awareness.SetActive(false);
			currency.SetActive(false);
			meals.SetActive(false);
			build.SetActive(false);
			buy.SetActive(true);
			give.SetActive(false);
			music.SetActive(false);
			soundeffect.SetActive(false);
			donation.SetActive(false);
			pause.SetActive(false);
			play.SetActive(false);
			exit.SetActive(false);
			upgrade.SetActive(false);
			truck.SetActive(false);
			go.SetActive(false);
			break;
		case 6:
			helpMessage.text = "This is the GIVE symbol, by clicking this you will physically begin unloading the meals from one of" +
				"your trucks and onto the schoo grounds. Once you have given the meals, your part is complete, the meals will be" +
				"distributed by the school. Giving meals is one way to gain AWARENESS!";
			awareness.SetActive(false);
			currency.SetActive(false);
			meals.SetActive(false);
			build.SetActive(false);
			buy.SetActive(false);
			give.SetActive(true);
			music.SetActive(false);
			soundeffect.SetActive(false);
			donation.SetActive(false);
			pause.SetActive(false);
			play.SetActive(false);
			exit.SetActive(false);
			upgrade.SetActive(false);
			truck.SetActive(false);
			go.SetActive(false);
			break;
		case 7:
			helpMessage.text = "This is the MUSIC symbol, if the symbol on the left is shown then music is currently playing," +
				"clicking on that button will mute the music playing, and the symbol on the right will be shown to help" +
				"remind you whether or not music is allowed!";
			awareness.SetActive(false);
			currency.SetActive(false);
			meals.SetActive(false);
			build.SetActive(false);
			buy.SetActive(false);
			give.SetActive(false);
			music.SetActive(true);
			soundeffect.SetActive(false);
			donation.SetActive(false);
			pause.SetActive(false);
			play.SetActive(false);
			exit.SetActive(false);
			upgrade.SetActive(false);
			truck.SetActive(false);
			go.SetActive(false);
			break;
		case 8:
			helpMessage.text = "This is the SOUND EFFECT symbol, if the symbol on the left is shown then sound effects are currently playing," +
				"clicking on that button will mute all game sound effects, and the symbol on the right will be shown to help" +
					"remind you whether or not sound effects are allowed!";
			awareness.SetActive(false);
			currency.SetActive(false);
			meals.SetActive(false);
			build.SetActive(false);
			buy.SetActive(false);
			give.SetActive(false);
			music.SetActive(false);
			soundeffect.SetActive(true);
			donation.SetActive(false);
			pause.SetActive(false);
			play.SetActive(false);
			exit.SetActive(false);
			upgrade.SetActive(false);
			truck.SetActive(false);
			go.SetActive(false);
			break;
		case 9:
			helpMessage.text = "This is the DONATION symbol, by clicking this you will be taken to the MARY'S MEALS DONATE page" +
				"where you can learn how to make regular donations to MARY'S MEALS, or even just a singular donation!";
			awareness.SetActive(false);
			currency.SetActive(false);
			meals.SetActive(false);
			build.SetActive(false);
			buy.SetActive(false);
			give.SetActive(false);
			music.SetActive(false);
			soundeffect.SetActive(false);
			donation.SetActive(true);
			pause.SetActive(false);
			play.SetActive(false);
			exit.SetActive(false);
			upgrade.SetActive(false);
			truck.SetActive(false);
			go.SetActive(false);
			break;
		case 10:
			helpMessage.text = "This is the PAUSE symbol, if this symbol is displayed then the game is currently paused" +
				"and motion or gameplay will not continue. You can use this for a break, to restart the level, to look up help" +
				"or even to quit the game! Simply click the pause symbol again to resume play, and change the symbol to the play button.";
			awareness.SetActive(false);
			currency.SetActive(false);
			meals.SetActive(false);
			build.SetActive(false);
			buy.SetActive(false);
			give.SetActive(false);
			music.SetActive(false);
			soundeffect.SetActive(false);
			donation.SetActive(false);
			pause.SetActive(true);
			play.SetActive(false);
			exit.SetActive(false);
			upgrade.SetActive(false);
			truck.SetActive(false);
			go.SetActive(false);
			break;
		case 11:
			helpMessage.text = "This is the PLAY symbol, if this symbol is displayed then the game is currently playing at" +
				"normal speed. By clicking this button you will pause the game where you can view the numberous options in " +
				"the pause menu.";
			awareness.SetActive(false);
			currency.SetActive(false);
			meals.SetActive(false);
			build.SetActive(false);
			buy.SetActive(false);
			give.SetActive(false);
			music.SetActive(false);
			soundeffect.SetActive(false);
			donation.SetActive(false);
			pause.SetActive(false);
			play.SetActive(true);
			exit.SetActive(false);
			upgrade.SetActive(false);
			truck.SetActive(false);
			go.SetActive(false);
			break;
		case 12:
			helpMessage.text = "This is the EXIT symbol, if this symbol appears small then clicking it will simply exit the" +
				"current menu. If the symbol appears large then clicking on it will exit the level. You will be prompted with" +
				"a YES OR NO decision to confirm your choice.";
			awareness.SetActive(false);
			currency.SetActive(false);
			meals.SetActive(false);
			build.SetActive(false);
			buy.SetActive(false);
			give.SetActive(false);
			music.SetActive(false);
			soundeffect.SetActive(false);
			donation.SetActive(false);
			pause.SetActive(false);
			play.SetActive(false);
			exit.SetActive(true);
			upgrade.SetActive(false);
			truck.SetActive(false);
			go.SetActive(false);
			break;
		case 13:
			helpMessage.text = "This is the UPGRADE symbol, by clicking this button you will upgrade the current vehicle or" +
				"building that is active. E.g. If you have clicked on a vehicle and then the upgrade button, it will upgrade the" +
				"truck, not the building it is in. However the symbol should be displayed above the to be upgraded item.";
			awareness.SetActive(false);
			currency.SetActive(false);
			meals.SetActive(false);
			build.SetActive(false);
			buy.SetActive(false);
			give.SetActive(false);
			music.SetActive(false);
			soundeffect.SetActive(false);
			donation.SetActive(false);
			pause.SetActive(false);
			play.SetActive(false);
			exit.SetActive(false);
			upgrade.SetActive(true);
			truck.SetActive(false);
			go.SetActive(false);
			break;
		case 14:
			helpMessage.text = "This is the TRUCK symbol, the presence of this symbol indicates a truck is taking up a spot in" +
				"one of your kitchens. Clicking it will reveal all the necessary stats about the truck including the speed" +
				"or the truck, conditon of it, its load capacity, and whether or not it is fully loaded.";
			awareness.SetActive(false);
			currency.SetActive(false);
			meals.SetActive(false);
			build.SetActive(false);
			buy.SetActive(false);
			give.SetActive(false);
			music.SetActive(false);
			soundeffect.SetActive(false);
			donation.SetActive(false);
			pause.SetActive(false);
			play.SetActive(false);
			exit.SetActive(false);
			upgrade.SetActive(false);
			truck.SetActive(true);
			go.SetActive(false);
			break;
		case 15:
			helpMessage.text = "This is the GO symbol, by clicking on this button, the currently active truck that you have" +
				"selected will begin its journey that you have set out for it by using nodes. Nodes are displayed on the right" +
				"of the GO symbol.";
			awareness.SetActive(false);
			currency.SetActive(false);
			meals.SetActive(false);
			build.SetActive(false);
			buy.SetActive(false);
			give.SetActive(false);
			music.SetActive(false);
			soundeffect.SetActive(false);
			donation.SetActive(false);
			pause.SetActive(false);
			play.SetActive(false);
			exit.SetActive(false);
			upgrade.SetActive(false);
			truck.SetActive(false);
			go.SetActive(true);
			break;
		case 16:
			helpMessage.text = "";
			clickToLearnMessage.text = "";
			break;
		}
	}

	public void awarenessHelp(){
		helpMessageNumber = 1;
	}
	public void currencyHelp(){
		helpMessageNumber = 2;
	}
	public void mealHelp(){
		helpMessageNumber = 3;
	}
	public void buildHelp(){
		helpMessageNumber = 4;
	}
	public void buyHelp(){
		helpMessageNumber = 5;
	}
	public void giveHelp(){
		helpMessageNumber = 6;
	}
	public void musicHelp(){
		helpMessageNumber = 7;
	}
	public void soundeffectHelp(){
		helpMessageNumber = 8;
	}
	public void donationHelp(){
		helpMessageNumber = 9;
	}
	public void pauseHelp(){
		helpMessageNumber = 10;
	}
	public void playHelp(){
		helpMessageNumber = 11;
	}
	public void quitHelp(){
		helpMessageNumber = 12;
	}
	public void upgradeHelp(){
		helpMessageNumber = 13;
	}
	public void truckHelp(){
		helpMessageNumber = 14;
	}
	public void goHelp(){
		helpMessageNumber = 15;
	}
	public void closeHelpIcons(){
		Debug.Log ("Close all help buttons");
		helpMessageNumber = 16;
		awareness.SetActive(false);
		currency.SetActive(false);
		meals.SetActive(false);
		build.SetActive(false);
		buy.SetActive(false);
		give.SetActive(false);
		music.SetActive(false);
		soundeffect.SetActive(false);
		donation.SetActive(false);
		pause.SetActive(false);
		play.SetActive(false);
		exit.SetActive(false);
		upgrade.SetActive(false);
		truck.SetActive(false);
		go.SetActive(false);
		helpMessage.text = "";
		clickToLearnMessage.text = "";
		awarenessButton.SetActive (false);
		currencyButton.SetActive (false);
		mealButton.SetActive (false);
		buildButton.SetActive (false);
		buyButton.SetActive (false);
		giveButton.SetActive (false);
		musicButton.SetActive (false);
		soundeffectButton.SetActive (false);
		donationButton.SetActive (false);
		pauseButton.SetActive (false);
		playButton.SetActive (false);
		exitButton.SetActive (false);
		upgradeButton.SetActive (false);
		truckButton.SetActive (false);
		goButton.SetActive (false);
		helpMenuBackground.SetActive (false);
		exitHelpButton.SetActive (false);


	}

	public void openHelpMenu(){
		helpMessageNumber = 0;
		helpMessage.text = "Click a button on the left to have its help and information listed here.";
		clickToLearnMessage.text = "Click any button to learn what it does!";
		awarenessButton.SetActive (true);
		currencyButton.SetActive (true);
		mealButton.SetActive (true);
		buildButton.SetActive (true);
		buyButton.SetActive (true);
		giveButton.SetActive (true);
		musicButton.SetActive (true);
		soundeffectButton.SetActive (true);
		donationButton.SetActive (true);
		pauseButton.SetActive (true);
		playButton.SetActive (true);
		exitButton.SetActive (true);
		upgradeButton.SetActive (true);
		truckButton.SetActive (true);
		goButton.SetActive (true);
		helpMenuBackground.SetActive (true);
		exitHelpButton.SetActive (true);
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test ()
	{
		Debug.Log ("Hello!");
	}
}
