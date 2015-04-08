using UnityEngine;
using System.Collections;

public class DontDestroyOnLoadScript : MonoBehaviour
{

	public static bool created = false;
	
	// Use this for initialization
	void Start ()
	{
//		if (!created) {
//			DontDestroyOnLoad (this.gameObject);
//			created = true;
//		} else {
//			Destroy (this.gameObject);
//		}

		if (GameObject.FindGameObjectsWithTag (this.gameObject.tag).Length > 1) {
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
	}
}
