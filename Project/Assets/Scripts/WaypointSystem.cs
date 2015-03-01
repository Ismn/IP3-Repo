using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* ***************
 * Ross McIntyre, 
 * IP3 Team 4,
 * 2015
 * ***************
 * Code adapted from forum post here:
 * http://forum.unity3d.com/threads/a-waypoint-script-explained-in-super-detail.54678/
 * ***************
 * Credit to user "Cherub" for the original post;
 * and to Michael Adaixo, user "Mikea15", for translating it from JavaScript to C#
 * ***************
 */

public class WaypointSystem : MonoBehaviour
{	
	// This is as fast the object is allowed to go.
	public float speedLimit = 10.0f;

	private float speed = 5.0f;
	
	// This variable will store the "active" target object (the waypoint to move to).
	private Transform currentWaypoint;

	// Holds all the Waypoint Objects that you assign in the inspector.
	public List<Transform> waypoints;
	
	// This variable keeps track of which Waypoint Object,
	// in the previously mentioned array variable "waypoints", is currently active.
	private int WPindexPointer;

	//The function "Start()" is called just before anything else but only one time.
	void Start( )
	{
	}
	
	//The function "Update()" is called every frame. It can get slow if overused.
	void Update ()
	{		
		currentWaypoint = waypoints[WPindexPointer]; //Keep the object pointed toward the current Waypoint object.
		Debug.Log(WPindexPointer);
		transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);
	}
	
	//The function "OnTriggerEnter" is called when a collision happens.
	void OnTriggerEnter ()
	{		
		// When the GameObject collides with the waypoint's collider,
		// change the active waypoint to the next one in the array variable "waypoints".
		WPindexPointer++;
		Debug.Log(WPindexPointer);
		// When the array variable reaches the end of the list ...
		if (WPindexPointer >= waypoints.Count)
		{
			// ... reset the active waypoint to the first object in the array variable
			// "waypoints" and start from the beginning.
			WPindexPointer = 0;
		}
	} 
}