using UnityEngine;
using System.Collections;

public class Road : Obj
{

	public bool built = false;
	public int movementSpeed;
	public Sprite[] pathTypes;

	public enum State
	{
		unbuilt,
		basicRoad,
		upgradedRoad		
	};

	public State currentState;

	public override void OnTouch ()
	{
		base.OnTouch ();
		if (currentState == State.unbuilt) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = pathTypes [1];
			Debug.Log ("road built!");
			built = true;
			currentState = State.basicRoad;
		} else if (currentState == State.basicRoad) {
			currentState = State.upgradedRoad;
			Debug.Log ("upgraded road!");
		}
	
	}
}
