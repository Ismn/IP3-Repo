using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Ross McIntyre, 
 * IP3 Team 4,
 * 2015
 */

public class NodeBehaviour : MonoBehaviour
{
	// Declare objects to interact with.
	SpriteRenderer sRender;
	public Sprite selectedNode;
	public Sprite unselectedNode;

	// Do the same for collections.
	public List<Transform> nodeList = new List<Transform>();

	// And variables.
	public bool renderNodeSprite;
	public bool timeToChange;
	public bool clicked;

	// Use this for initialization
	void Start () 
	{
		sRender = GetComponent<SpriteRenderer>();

		clicked = false;

		renderNodeSprite = false; // Node sprites are not to be rendered on startup.
		timeToChange = false; // Nor are they to be shown in their 'selected' state.
	}
	
	// Update is called once per frame
	void Update () 
	{	
		// Assuming the character has been selected...
		if (renderNodeSprite == true)
		{
			// ... make all node sprites visible as "unselected".
			sRender.sprite = unselectedNode;
		}

		// If the unselected sprites are visible...
		if (sRender.sprite == unselectedNode && timeToChange)
		{
			// ... highlight the ones we have selected.
			sRender.sprite = selectedNode;
		}
	}

	// OnMouseDown checks for clicks on Colliders and GUI elements.
	void OnMouseDown()
	{
		clicked = true;
		timeToChange = true;
		nodeList.Add (this.transform);
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test()
	{
		Debug.Log ("Hello!");
	}
}
