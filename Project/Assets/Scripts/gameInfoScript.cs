using UnityEngine;
using System.Collections;

public class gameInfoScript : MonoBehaviour
{


	public static bool levelOneAfricaPlayedBefore;
	public bool _levelOneAsiaPlayedBefore;
	public bool _levelOneAfricaPlayedBefore;
	public bool _levelTwoAfricaPlayedBefore;

	// Use this for initialization
	void Start ()
	{
		//if(gameObject.Find("toCheckForLevelsPlayed") != null){
		//	levelOneAfricaPlayedBefore = false;
		//
		_levelOneAsiaPlayedBefore = false;
		_levelOneAfricaPlayedBefore = false;
		_levelTwoAfricaPlayedBefore = false;
	
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
