using UnityEngine;
using System.Collections;


public class House : Obj
{
	static gamePlayScript gameplayScript;

	public GameObject upgradedSchool;

	public Sprite[] buildingTypes;
	//public bool building = false;
	public bool built = false;
	public int capacity;
	public GameObject testplzwork;

	public enum State
	{
		unbuilt,
		smallSchool,
		bigSchool		
	}
	;

	public State currentState;

	public void Start ()
	{

	}

	public override void OnTouch ()
	{
		base.OnTouch ();
		Debug.Log ("click");
		if (currentState == State.unbuilt) {
			testplzwork.GetComponent<gamePlayScript> ().money -= 10;
			Destroy (this.gameObject);
			GameObject upgrade = (GameObject)Instantiate (upgradedSchool, this.transform.position, Quaternion.Euler (270, 270, 0));
			currentState = State.smallSchool;
		} else if (currentState == State.smallSchool) {
			Debug.Log ("school upgraded!");
		}
	}


}
