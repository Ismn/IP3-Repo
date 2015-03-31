using UnityEngine;
using System.Collections;

//this script allows the player to pan the camera around the game space

public class cameraMoveScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float xAxisValue = Input.GetAxis ("Horizontal");
		float zAxisValue = Input.GetAxis ("Vertical");
		if (Camera.current != null) {
			Camera.current.transform.Translate (new Vector3 (xAxisValue, 0.0f, zAxisValue), Space.World);
		}
	}
}
