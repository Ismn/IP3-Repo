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
	private Transform currentWP; // Stores the "active" target object (the waypoint to move to).

	// Do the same for collections.
	public Transform[] WPArray; // Holds every object tagged as "BirdWaypoint"

	// And variables.
	public int BirdWPIndex; // Keep track of which Waypoint Object is currently defined as 'active' in the Array - defined in Inspector.
	private float speed; // How fast the boids can move.
	private float rotationSpeed; // How fast they can turn towards a node.
	private Vector3 targetDirection; // Store the positional information of the target node.
	private Vector3 newDirection; // Store information to rotate the boids towards the target node.

	// I'm really strechting this 'boids' in-joke to its limits, aren't I?

	// Use this for initialization
	void Start ()
	{
		BirdWPIndex = 0;
		speed = 12.0f * Time.deltaTime;
		rotationSpeed = 30.0f * Time.deltaTime;
	}

	// FixedUpdate is called once per frame in a non-fluctating manner.
	// Also no longer requires the use of delta time.
	void Update ()
	{
		currentWP = WPArray [BirdWPIndex];
		if (WPArray.Length > 0) {
			// MoveTowards function takes its parameters as (current position, target position, speed).
			transform.position = Vector3.MoveTowards (transform.position, currentWP.position, speed);			
			
			// Some stuff for rotation.
			targetDirection = currentWP.position - transform.position;
			newDirection = Vector3.RotateTowards (transform.forward, targetDirection, rotationSpeed, 0.0F);
			transform.rotation = Quaternion.LookRotation (newDirection);
		}
	}

	// The function "OnTriggerEnter" is called when a collision happens.
	void OnTriggerEnter (Collider other)
	{
		// If the bird comes within range of an object with the "BirdWaypoint" tag...
		if (other.gameObject.CompareTag ("BirdWaypoint")) {
			// ... Set the active waypoint to the next element in the array.
			BirdWPIndex++;
		}
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