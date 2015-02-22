using UnityEngine;
using System.Collections;

public class House : Obj
{

	public Sprite[] buildingTypes;
	public bool built = false;
	public int capacity;

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
