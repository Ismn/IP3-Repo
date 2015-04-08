using UnityEngine;
using System.Collections;

public class gameInfoScript : MonoBehaviour {

	public static bool levelOneAfricaPlayedBefore;

	// Use this for initialization
	void Start () {
		//if(gameObject.Find("toCheckForLevelsPlayed") != null){
		//	GameObject.Destroy(gameObject);
		//}
		levelOneAfricaPlayedBefore = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == ("LevelOneAfrica")) {
			levelOneAfricaPlayedBefore = true;
		}
		GameObject.DontDestroyOnLoad (gameObject);
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test ()
	{
		Debug.Log ("Hello!");
	}
}
