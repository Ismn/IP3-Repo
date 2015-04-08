/* ******************
 * Ross McIntyre, 
 * IP3 Team 4,
 * 2015
 * ******************
 */

using UnityEngine;
using System.Collections;

public class SchoolBehaviour : MonoBehaviour
{
	// Declare objects to interact with.
	public GameObject refToGamePlayScript;
	public GameObject truck;
	public AudioClip schoolSound;
	public GameObject refToCharBehaviourScript;

	// Do the same for collections.

	// And variables.

	// Called when the instance of the script is being loaded.
	void Awake ()
	{
		// Reference any Game Objects tagged as "Character" i.e. the trucks.
		truck = GameObject.FindGameObjectWithTag ("Character");
	}

	void OnMouseDown ()
	{
		// Add this instance to the List of Nodes for the trucks to follow.
		truck.GetComponent<CharacterBehaviour> ().waypoints.Add (this.transform);
		if (refToCharBehaviourScript.GetComponent<CharacterBehaviour> ().truckIsSelected == true) {
			audio.PlayOneShot (schoolSound);
		}
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test ()
	{
		Debug.Log ("Hello!");
	}
}
