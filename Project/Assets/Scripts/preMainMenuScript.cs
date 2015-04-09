using UnityEngine;
using System.Collections;

public class preMainMenuScript : MonoBehaviour {

	public GameObject play;
	public GameObject quit;
	
	void takeMeToMainMenu(){
		Application.LoadLevel ("MainMenu");
	}

	void quitTheGameEntirely(){
		Application.Quit ();
	}
}
