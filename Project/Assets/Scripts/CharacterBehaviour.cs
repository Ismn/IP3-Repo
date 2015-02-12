using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Ross McIntyre, 
 * IP3 Team 4,
 * 2013
 */

public class CharacterBehaviour : MonoBehaviour 
{
	// Declare objects to interact with.
	public GameObject nodes;
	public GameObject[] nodeArray;

	public List<GameObject> nodeList = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{	
		nodeArray = GameObject.FindGameObjectsWithTag("Node");

		for(int i = 0; i < nodeArray.Length; i++)
		{
			// Add them to the list
			nodeList.Add(nodes);
			Debug.Log(nodeList.Count);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	// OnMouseDown checks for clicks on Colliders and GUI elements.
	void OnMouseDown()
	{
		// If we press down the Left Mouse Button...
		if(Input.GetMouseButtonDown(0))
		{
			foreach(GameObject nodes in nodeList)
			{
				// ... Tell the object to either begin rendering a sprite or change the current one.
				nodes.GetComponent<NodeBehaviour>().Test();
			}
			Debug.Log("You clicked LMB on the character");
		}
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test()
	{
		Debug.Log ("Hello!");
	}
}