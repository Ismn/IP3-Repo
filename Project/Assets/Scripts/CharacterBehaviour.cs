
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
	public GameObject testplzwork;

	// Do the same for collections.
	public List <Transform> waypoints = new List<Transform> (); // Holds all the Waypoint Objects that you assign in the inspector.
	public GameObject[] nodeArray;

	// And variables.
	private float speed; // How fast the players trucks can move.
	private float rotationSpeed; // How fast it can turn towards the a node.
	private float timeToUnload = 1.0f;
	private Vector3 targetDirection; // Store the positional information of the 
	private Vector3 newDirection;
	private bool hasBeenClicked;
	private bool showNode;
	public bool canMove;
	static int WPindexPointer; // Keep track of which Waypoint Object, is currently defined as 'active' in the array.
	public bool truckIsSelected = false;
	// Use this for initialization
	void Start ()
	{
		nodeArray = GameObject.FindGameObjectsWithTag ("Node");		

		WPindexPointer = 0; // Waypoint target is first element in the Array.

		speed = 5.0f * Time.deltaTime;
		rotationSpeed = 10.0f * Time.deltaTime;

		hasBeenClicked = false;
		showNode = false;
		canMove = false;

	}
	
	// Update is called once per frame
	public void Update ()
	{
		//	Debug.Log (canMove);

		//if (waypoints.Count > 0) {
		currentWaypoint = waypoints [WPindexPointer]; //Keep the object pointed toward the current Waypoint object.
		if (canMove == true) {
			hasBeenClicked = false;

			if (waypoints.Count > 0) {
				// MoveTowards function takes its paramettraers as (current position, target position, speed).
				transform.position = Vector3.MoveTowards (transform.position, currentWaypoint.position, speed);			

				// Some stuff for rotation.
				targetDirection = currentWaypoint.position - transform.position;
				newDirection = Vector3.RotateTowards (transform.forward, targetDirection, rotationSpeed, 0.0F);
				transform.rotation = Quaternion.LookRotation (newDirection);
			}
		}
		//}
	}

	// OnMouseDown checks for clicks on Colliders and GUI elements.
	public void OnMouseDown () // When we click on the truck...
	{
		truckIsSelected = true;
		testplzwork.GetComponent<gamePlayScript> ().goButton.SetActive (true);
		Debug.Log ("truckclick");

		// Toggle function to determine whether or not to show all the nodes in view, 
		// since it's only necessary to see them when we tell a truck where to go.
		if (showNode == false) {
			foreach (GameObject nodes in nodeArray) {
				// ... Tell the Node object to begin rendering the 'unselected' sprite.
				nodes.GetComponent<NodeBehaviour> ().renderNodeSprite = true;
			}
			showNode = true;
		} else if (showNode == true) {
			foreach (GameObject nodes in nodeArray) {
				// ... Tell the Node object to stop rendering sprites.
				nodes.GetComponent<NodeBehaviour> ().renderNodeSprite = false;
			}
			showNode = false;
		}

		// Play a short audio clip to let the player know they've selected a truck.
		audio.Play ();

		// Toggle function to ensure that the truck cannot move the second a node is selected.
		if (hasBeenClicked == false) {
			hasBeenClicked = true;
			Time.timeScale = 0.0f;
		} else if (hasBeenClicked == true) {
			hasBeenClicked = false;
			Time.timeScale = 1.0f;
		}
	}

	//The function "OnTriggerEnter" is called when a collision happens.
	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Has Entered trigger");
		// If the truck comes within range of an object with the "Node" tag...
		if (other.CompareTag ("Node")) {
			// ... Set the active waypoint to the next element in the array.
			WPindexPointer++;
		}
		
		if (other.tag == ("School")) {
			StartCoroutine (Unloading ());
			Debug.Log ("enterschool");
			testplzwork.GetComponent<gamePlayScript> ().dropOff = true;
			testplzwork.GetComponent<gamePlayScript> ().canUnload = true;
			Test ();
		}
	}

	void OnTriggerStay (Collider other)
	{
		//	Debug.Log ("enter trigger");
		if (other.tag == ("School")) {
			Debug.Log ("Bacon");
			testplzwork.GetComponent<gamePlayScript> ().dropOff = true;
			testplzwork.GetComponent<gamePlayScript> ().canUnload = true;
		}
		if (other.tag == ("kitchen")) {
			testplzwork.GetComponent<gamePlayScript> ().canHasBuyMeals = true;
		}

	}
	public void OnTriggerExit (Collider other)
	{
		if (other.tag == ("kitchen")) {
			testplzwork.GetComponent<gamePlayScript> ().canHasBuyMeals = false;
			Debug.Log ("leaveKitchen");
		}
	}

	// Currently a code stub. Definitely needs more work.
	public IEnumerator Unloading ()
	{
		speed = 0.0f;

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