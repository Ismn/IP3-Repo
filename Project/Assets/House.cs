using UnityEngine;
using System.Collections;

public class House : Obj
{

	public Sprite[] buildingTypes;
	public bool built = false;

	public override void OnTouch ()
	{
		base.OnTouch ();
		Debug.Log ("Knock Knock");
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = buildingTypes [1];
	}
}
