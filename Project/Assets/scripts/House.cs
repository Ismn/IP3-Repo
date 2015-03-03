using UnityEngine;
using System.Collections;

public class House : Obj
{

	public Sprite[] buildingTypes;
	//public bool building = false;
	public bool built = false;
	public int capacity;

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
		currentState = State.unbuilt;
	}

	public override void OnTouch ()
	{
		base.OnTouch ();

		if (currentState == State.unbuilt) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = buildingTypes [1];
			Debug.Log ("building built");
			built = true;
			currentState = State.smallSchool;
		} else if (currentState == State.smallSchool) {
			currentState = State.bigSchool;
			Debug.Log ("school upgraded!");
		}
	}

}
