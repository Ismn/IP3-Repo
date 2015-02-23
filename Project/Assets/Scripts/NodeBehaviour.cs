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
	public static List<Transform> targetList; 

	// Do the same for variables
	public bool renderNodeSprite;
	public bool timeToChange;
	public Transform target;

	// Use this for initialization
	void Start () 
	{
		targetList = new List<Transform>();
		target = this.gameObject.transform;
		sRender = GetComponent<SpriteRenderer>();

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
		setAsTarget();
	}

	public List<Transform> setAsTarget()
	{
		// If we click on a node which has already been made visible...
		if(renderNodeSprite == true)
		{
			// ... Change the sprite to show it has been selected and add it
			// to an array of transforms for the character to move to.
			timeToChange = true;
			targetList.Add(target);
			foreach (Transform trans in targetList)
			{
				return trans.transform;
			}
		}
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test()
	{
		Debug.Log ("Hello!");
	}
}
