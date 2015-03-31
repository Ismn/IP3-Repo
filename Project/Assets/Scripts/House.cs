using UnityEngine;
using System.Collections;

//this script detects when a building is clicked and upgrades it

public class House : Obj
{
	static gamePlayScript gameplayScript;

	public GameObject upgradedSchool;

	public Sprite[] buildingTypes;
	public bool built = false;
	public int capacity;
	public GameObject refToGameplayScript;
	public GameObject refToTutScript;

	public enum State
	{
		unbuilt,
		smallSchool,
		bigSchool		
	}
	;

	public State currentState;

	public override void OnTouch ()
	{
		base.OnTouch ();
		if (currentState == State.unbuilt) {
			refToGameplayScript.GetComponent<gamePlayScript> ().money -= 10;
			refToTutScript.GetComponent<TutorialScript> ().tutBuildingBuilt = true;
			Destroy (this.gameObject);
			GameObject upgrade = (GameObject)Instantiate (upgradedSchool, this.transform.position, Quaternion.Euler (270, 270, 0));
			currentState = State.smallSchool;
		} else if (currentState == State.smallSchool) {
			;
		}
	}


}
