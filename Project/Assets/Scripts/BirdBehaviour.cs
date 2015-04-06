/* ******************
 * Ross McIntyre, 
 * IP3 Team 4,
 * 2015
 * ******************
 */

using UnityEngine;
using System.Collections;

public class BirdBehaviour : MonoBehaviour 
{
	// Declare objects to interact with.
	// private Transform currentWP; // Stores the "active" target object (the waypoint to move to).

	// Do the same for collections.
	// public Array of Transforms (Transform is a word for the position, rotation and scale of an object in 3D space)... lets call it - BirdWPArray // Holds every object tagged as "BirdWaypoint"

	// And variables.
	// public integer, but invisible to the inspector called, lets call it - BirdWPindex // Keep track of which Waypoint Object is currently defined as 'active' in the Array - defined in Inspector.
	// floating point number called speed - we only want this to be accessible by this script // How fast the boids can move.
	// private float rotationSpeed; // How fast they can turn towards a node.
	// private Vector3 targetDirection; // Store the positional information of the target node.
	// private Vector3 newDirection; // Store information to rotate the boids towards the target node.

	// I'm really strechting this 'boids' in-joke to its limits, aren't I?

	// Use this for initialization
	void Start () 
	{
		// Waypoint Index = 0;
		// Our movement speed = 12.0f * Time.deltaTime;
		// How fast we want to rotate to the target = 30.0f * Time.deltaTime;
	}

	// FixedUpdate is called once per frame in a non-fluctating manner.
	// Also no longer requires the use of delta time.
	void FixedUpdate () 
	{
		// Our current Waypoint = BirdWPArray [BirdWPindex];
		// if (Our Waypoint Index is greater than 0)
		{
			// MoveTowards function takes its parameters as (current position, target position, speed).
			// transform.position = Vector3.MoveTowards (transform.position, currentWP.position, speed);			
			
			// Some stuff for rotation.
			// targetDirection = .position - transform.position;
			// newDirection = Vector3.RotateTowards (transform.forward, , rotationSpeed, 0.0F);
			// transform.rotation = Quaternion.LookRotation ();
		}
	}

	// The function "OnTriggerEnter" is called when a collision happens.
	void OnTriggerEnter (Collider other)
	{
		// If the bird comes within range of an object with the "BirdWaypoint" tag...
		// if the other collider has a tag called "BirdWaypoint", then {
			// ... Set the active waypoint to the next element in the array.

			/* TO DO:
			 * Set the index to count up.
			 */

		//}
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test ()
	{
		Debug.Log ("Hello!");
	}
}

/*
 * Boids... !
 */