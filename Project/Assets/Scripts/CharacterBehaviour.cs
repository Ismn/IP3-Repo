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
 * Changes to Waypoint Script over original include:
 * Using a List instead of an array - Allows waypoints to be assigned in any order at runtime.
 * Removal of factors such as acceleration, inertia, variable speed limits and rotation (may be re-implemented later).
 * Removal of state machine to control movement. (Again, may be re-implemented later).
 * Integration with overall behaviour of the trucks.
 * ***************
 * Rotation code taken from Unity Scripting API:
 * http://docs.unity3d.com/ScriptReference/Vector3.RotateTowards.html
 * ***************
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterBehaviour : MonoBehaviour
{
	// Declare objects to interact with.
	private Transform currentWaypoint; // Stores the "active" target object (the waypoint to move to).
	static gamePlayScript gPS;

	// Do the same for collections.
	public List <Transform> waypoints = new List<Transform> (); // Holds all the Waypoint Objects that you assign in the inspector.
	public GameObject[] nodeArray;

	// And variables.
	private float speed; // How fast the players trucks can move.
	private float rotationSpeed;
	private float timeToUnload = 1.0f;
	private Vector3 targetDirection;
	private Vector3 newDirection;
	private bool hasBeenClicked;
	static int WPindexPointer; // Keep track of which Waypoint Object, is currently defined as 'active' in the array.

	// Use this for initialization
	void Start ()
	{
		gPS = GetComponent<gamePlayScript> ();

		nodeArray = GameObject.FindGameObjectsWithTag ("Node");		
		Debug.Log (nodeArray.Length);

		WPindexPointer = 0; // Waypoint target is first element in the Array.
		Debug.Log (WPindexPointer);

		speed = 5.0f * Time.deltaTime;
		rotationSpeed = 10.0f * Time.deltaTime;

		hasBeenClicked = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentWaypoint = waypoints [WPindexPointer]; //Keep the object pointed toward the current Waypoint object.
		if (waypoints.Count > 0) {
			// MoveTowards function takes its parameters as (current position, target position, speed).
			transform.position = Vector3.MoveTowards (transform.position, currentWaypoint.position, speed);

			//targetDirection = currentWaypoint.position - transform.position;
			//newDirection = Vector3.RotateTowards (transform.right, targetDirection, rotationSpeed, 0.0F);
			//transform.rotation = Quaternion.LookRotation (newDirection);
		}
	}

	// OnMouseDown checks for clicks on Colliders and GUI elements.
	void OnMouseDown () // When we click on the truck...
	{
		foreach (GameObject nodes in nodeArray) {
			// ... Tell the Node object to either begin rendering the 'unselected' sprite.
			nodes.GetComponent<NodeBehaviour> ().renderNodeSprite = true;
		}
		audio.Play();


		if (hasBeenClicked == false) 
		{
			hasBeenClicked = true;
			Time.timeScale = 0;
		} 
		else if (hasBeenClicked == true) 
		{
			hasBeenClicked = false;
			Time.timeScale = 1;
		}
	}

	//The function "OnTriggerEnter" is called when a collision happens.
	void OnTriggerEnter (Collider other)
	{
		// If the truck comes within range of an object with the "Node" tag...
		if (other.CompareTag ("Node")) {
			// ... Set the active waypoint to the next element in the array.
			WPindexPointer++;
		}
		
		if (other.CompareTag ("School")) {
			StartCoroutine (Unloading ());			
			Test ();
		}
	}

	// Currently a code stub. Definitely needs more work.
	public IEnumerator Unloading ()
	{
		speed = 0.0f;
		
		gPS.GetComponent<gamePlayScript> ().canUnload = true;
		yield return new WaitForSeconds (timeToUnload);
		
		this.collider.enabled = false;
		
		if (timeToUnload >= 1.0f) {
			speed = 5.0f;
		}
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test ()
	{
		Debug.Log ("Hello!");
	}
}