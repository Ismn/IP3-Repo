using UnityEngine;
using System.Collections;

/* Ross McIntyre, 
 * IP3 Team 4,
 * 2013
 */

public class NodeBehaviour : MonoBehaviour
{
	//private GameObject navNode;

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
			Debug.Log("renderNodeSprite is true");
		}
		if (sRender.sprite == unselectedNode && timeToChange)
		{
			sRender.sprite = selectedNode;
			Debug.Log("timeToChange is true");
		}
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test()
	{
		Debug.Log ("Hello!");
	}
}
