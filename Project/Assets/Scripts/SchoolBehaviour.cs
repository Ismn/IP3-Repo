/* Ross McIntyre, 
 * IP3 Team 4,
 * 2015
 */

using UnityEngine;
using System.Collections;

public class SchoolBehaviour : MonoBehaviour 
{
	// Declare objects to interact with.
	public GameObject testplzwork;
	public GameObject truck;

	// Do the same for collections.

	// And variables.

	// Called when the instance of the script is being loaded.
	void Awake () 
	{
		// Reference any Game Objects tagged as "Character" i.e. the trucks.
		truck = GameObject.FindGameObjectWithTag("Character");
	}
	
	// Update is called once per frame
	void Update () 
	{	
	}

	void OnCollision(Collider other)
	{
		/*Test ();

		if(other.CompareTag("Character"))
		{
			testplzwork.GetComponent<gamePlayScript> ().canUnload = true;
		}*/
	}

	void OnMouseDown()
	{
		// Add this instance to the List of Nodes for the trucks to follow.
		truck.GetComponent<CharacterBehaviour>().waypoints.Add(this.transform); 
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test ()
	{
		Debug.Log ("Hello!");
	}
}
