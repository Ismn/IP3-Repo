using UnityEngine;
using System.Collections;

public class Road : Obj
{

	public bool built = false;
	public int movementSpeed;
	public Sprite[] pathTypes;

	public override void OnTouch ()
	{
		base.OnTouch ();
		if (currentState == State.unbuilt) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = pathTypes [1];
			Debug.Log ("road built!");
			built = true;
			currentState = State.smallSchool;
		} else if (currentState == State.smallSchool) {
			currentState = State.bigSchool;
			Debug.Log ("upgraded road!");
		}
	
	}
}
