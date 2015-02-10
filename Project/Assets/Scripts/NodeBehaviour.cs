using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeBehaviour : MonoBehaviour
{
	// Define a node.
	public GameObject node;
	// Define what the spawnpoint for nodes is.
	private GameObject nodeSpawn;

	// Create a list to store these nodes in.
	List<NodeBehaviour> nodeList = new List<NodeBehaviour>();

	// Use this for initialization
	void Start () 
	{
		nodeSpawn = this.gameObject;
		
		// Using the length of the array as a parameter, populate the list with the Nodes through instancing.
		for(int i = 0; i < 1; i++)
		{
			// Instance the the nodes - Instantiate(prefab, position, rotation)
			NodeBehaviour nodes = Instantiate(node, this.transform.position, this.transform.rotation) as NodeBehaviour;
			// Add them to the list
			nodeList.Add(nodes);
			Debug.Log(nodeList.Count);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{	
	}
}
