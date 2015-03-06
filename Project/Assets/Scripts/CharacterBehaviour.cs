using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* ***************
 * Ross McIntyre, 
 * IP3 Team 4,
 * 2015
 * ***************
 * Waypoint code stripped down and adapted from forum post here:
 * http://forum.unity3d.com/threads/a-waypoint-script-explained-in-super-detail.54678/
 * ***************
 * Credit to user "Cherub" for the original post;
 * and to Michael Adaixo, user "Mikea15", for translating it from JavaScript to C#
 * ***************
 */

public class CharacterBehaviour : MonoBehaviour 
{
	// Declare objects to interact with.
	public GameObject[] nodeArray;
	private Transform currentWaypoint; // Stores the "active" target object (the waypoint to move to).
	public Transform[] waypoints; // Holds all the Waypoint Objects that you assign in the inspector.
	public gamePlayScript gPS;

	// Do the same for collections.

	// And variables.
	private float speed = 5.0f; // How fast the players trucks can move.
	static int WPindexPointer; // Keep track of which Waypoint Object, is currently defined as 'active' in the array.
	static bool canMove;
	//private float timeToUnload = 1.0f;

	// Use this for initialization
	void Start () 
	{
		canMove = false;

		nodeArray = GameObject.FindGameObjectsWithTag("Node");		
		Debug.Log(nodeArray.Length);

		WPindexPointer = 0; // Waypoint target is first element in the Array.
		Debug.Log (WPindexPointer);
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentWaypoint = waypoints [WPindexPointer]; //Keep the object pointed toward the current Waypoint object.
		if(canMove)
		{
			transform.position = Vector3.MoveTowards (transform.position, currentWaypoint.position, speed * Time.deltaTime); // MoveTowards function takes its parameters as (current position, target position, speed).
		}
	}

	// OnMouseDown checks for clicks on Colliders and GUI elements.
	void OnMouseDown()
	{
		canMove = true;

		foreach(GameObject nodes in nodeArray)
		{
			// ... Tell the object to either begin rendering a sprite or change the current one.
			nodes.GetComponent<NodeBehaviour>().renderNodeSprite = true;
		}
		Debug.Log("You clicked LMB on the character");
	}

	//The function "OnTriggerEnter" is called when a collision happens.
	public void OnTriggerEnter (Collider other)
	{
		// If the truck comes within range of an object with the "Node" tag...
		if (other.CompareTag ("Node")) 
		{
			Debug.Log ("Contact");
			
			// ...Set the active waypoint to the next element in the array.
			WPindexPointer++;
			Debug.Log (WPindexPointer);
			
			// When the array variable reaches the end of the list ...
			if (WPindexPointer >= waypoints.Length) 
			{
				// ... reset the active waypoint to the first object in the array,
				// effectivetly starting over from the beginning.
				WPindexPointer = 0;
			}
		}
		
		if (other.CompareTag("School"))
		{
			Unloading();
			
			Test();
		}
	}
	
	public void Unloading()
	{
		speed = 0.0f;
		
		gPS.GetComponent<gamePlayScript>().canUnload = true;
		//yield return new WaitForSeconds (timeToUnload);
		
		/*this.collider.enabled = false;
		
		if(timeToUnload >= 1.0f)
		{
			speed = 5.0f;
		}*/
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test()
	{
		Debug.Log ("Hello!");
	}
}