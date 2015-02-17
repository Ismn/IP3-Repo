using UnityEngine;
using System.Collections;

/* Ross McIntyre, 
 * IP3 Team 4,
 * 2015
 */

public class NodeBehaviour : MonoBehaviour
{
	SpriteRenderer sRender;
	public Sprite selectedNode;
	public Sprite unselectedNode;

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

	// Code stub for testing interaction between objects and scripts.
	public void Test()
	{
		Debug.Log ("Hello!");
	}
}
