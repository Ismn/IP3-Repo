using UnityEngine;
using System.Collections;

public class Obj : MonoBehaviour
{
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


	public virtual void OnTouch ()
	{

	}
}