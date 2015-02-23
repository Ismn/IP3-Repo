using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Ross McIntyre, 
 * IP3 Team 4,
 * 2015
 */

public class CharacterBehaviour : MonoBehaviour 
{
	// Declare objects to interact with.
	public NodeBehaviour nodes;
	public GameObject[] nodeArray;
	
	// Do the same for collections.
	List<Transform> transList = new List<Transform>();

	// And variables.
	public float speed;
	public float step;

	// Use this for initialization
	void Start () 
	{
		step = speed * Time.deltaTime;
		transList = nodes.nodeList;
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

	public void MoveToNode()
	{
		if (nodes.clicked == false)
		{
			return;

		}

		else 
		{
			do 
			{
				foreach (Transform trans in transList)
				{
					transform.position = Vector3.MoveTowards(transform.position, trans.position, step);
				}
			} 
			while (nodes.clicked == true);
		}
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test()
	{
		Debug.Log ("Hello!");
	}
}