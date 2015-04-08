/* Ross McIntyre, 
 * IP3 Team 4,
 * 2015
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeBehaviour : MonoBehaviour
{
	// Declare objects to interact with.
	SpriteRenderer sRender;
	public Sprite selectedNode;
	public Sprite unselectedNode;
	static GameObject charBehaviour;

	// Do the same for collections.

	// And variables.
	public bool renderNodeSprite;
	public bool timeToChange;
	public bool isNode;
	public bool isClicked;
	public AudioClip nodeClick;
	public AudioClip schoolClick;

	// Called when the instance of the script is being loaded.
	void Awake ()
	{
		// Reference any Game Objects tagged as "Character" i.e. the trucks.
		charBehaviour = GameObject.FindGameObjectWithTag ("Character");

		// Set a reference to Unity's Default Sprite Renderer.
		sRender = GetComponent<SpriteRenderer> ();

		renderNodeSprite = false; // Node sprites are not to be rendered on startup.
		timeToChange = false; // Nor are they to be shown in their 'selected' state.
		isNode = false;
		isClicked = false;
	}
	
	// Update is called once per frame
	void Update ()
	{	
		// Assuming the character has been selected...
		if (renderNodeSprite == true) {
			// ... make all node sprites visible as "unselected".
			sRender.sprite = unselectedNode;
		} else if (renderNodeSprite == false) {
			sRender.sprite = null;
		}
		// If the 'unselected' sprites are visible...
		if (sRender.sprite == unselectedNode && timeToChange) {
			// ... highlight the ones we have selected.
			sRender.sprite = selectedNode;
		}
	}

	// OnMouseDown checks for clicks on Colliders and GUI elements.
	void OnMouseDown ()
	{
		// Highlight whichever Node sprites have been clicked on.
		timeToChange = true; 
		audio.PlayOneShot (nodeClick);
		if (isClicked == false) {
			// Add this instance to the List of Nodes for the trucks to follow.
			charBehaviour.GetComponent<CharacterBehaviour> ().waypoints.Add (this.transform);
			isClicked = true;
		} else if (isClicked == true) {

			charBehaviour.GetComponent<CharacterBehaviour> ().waypoints.Remove (this.transform);
			isClicked = false;
			timeToChange = false;
		}
	}
}
