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
	static List<GameObject> targetList = new List<GameObject>();

	// Do the same for variables
	public bool renderNodeSprite;
	public bool timeToChange;

	// Use this for initialization
	void Start () 
	{
		//navNode = this.gameObject;
		sRender = GetComponent<SpriteRenderer>();

		renderNodeSprite = false;
		timeToChange = false;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if (renderNodeSprite == true)
		{
			sRender.sprite = unselectedNode;
		}
		if (sRender.sprite == unselectedNode && timeToChange)
		{
			sRender.sprite = selectedNode;
		}
	}

	// OnMouseDown checks for clicks on Colliders and GUI elements.
	void OnMouseDown()
	{
		if(renderNodeSprite == true)
		{
			timeToChange = true;
			targetList.Add(this.gameObject);
			Debug.Log(targetList.Count);
		}
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test()
	{
		Debug.Log ("Hello!");
	}
}
