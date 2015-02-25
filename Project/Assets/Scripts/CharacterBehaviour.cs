using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* ***************
 * Ross McIntyre, 
 * IP3 Team 4,
 * 2015
 * ***************
 */

public class CharacterBehaviour : MonoBehaviour 
{
	// Declare objects to interact with.
	public GameObject[] nodeArray;

	// Do the same for collections.

	// And variables.


	// Use this for initialization
	void Start () 
	{
		nodeArray = GameObject.FindGameObjectsWithTag("Node");
		
		Debug.Log(nodeArray.Length);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	// OnMouseDown checks for clicks on Colliders and GUI elements.
	void OnMouseDown()
	{
		foreach(GameObject nodes in nodeArray)
		{
			// ... Tell the object to either begin rendering a sprite or change the current one.
			nodes.GetComponent<NodeBehaviour>().renderNodeSprite = true;
		}
		Debug.Log("You clicked LMB on the character");
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test()
	{
		Debug.Log ("Hello!");
	}
}