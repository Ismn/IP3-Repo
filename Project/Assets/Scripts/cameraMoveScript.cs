using UnityEngine;
using System.Collections;

//this script allows the player to pan the camera around the game space

public class cameraMoveScript : MonoBehaviour
{
	public float speed = 0.1F;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		{
			float xAxisValue = Input.GetAxis ("Horizontal");
			float zAxisValue = Input.GetAxis ("Vertical");
			if (Camera.current != null) {
				Camera.current.transform.Translate (new Vector3 (xAxisValue, 0.0f, zAxisValue), Space.World);
			}
	
		
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
				Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
				transform.Translate (-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
			}
		}
	}


	//http://answers.unity3d.com/questions/517529/pan-camera-2d-by-touch.html
}