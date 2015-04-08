using UnityEngine;
using System.Collections;

public class gameInfoScript : MonoBehaviour
{


	public static bool levelOneAfricaPlayedBefore;
	public bool _levelOneAfricaPlayedBefore;

	// Use this for initialization
	void Start ()
	{
		//if(gameObject.Find("toCheckForLevelsPlayed") != null){
		//	levelOneAfricaPlayedBefore = false;
		//

		levelOneAfricaPlayedBefore = false;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//_levelOneAfricaPlayedBefore = levelOneAfricaPlayedBefore;
		if (Application.loadedLevelName == ("LevelOneAfrica")) {
			//levelOneAfricaPlayedBefore = true;
		}
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test ()
	{
		Debug.Log ("Hello!");
	}
}
