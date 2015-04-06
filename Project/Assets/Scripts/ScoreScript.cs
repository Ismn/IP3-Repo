using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//this script updates the player's awareness, money and meals as they are updated in the game

public class ScoreScript : MonoBehaviour
{

	Text score;
	// Use this for initialization
	void Start ()
	{
		score = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (this.gameObject.tag == "awareness") {
			score.text = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<gamePlayScript> ().awareness.ToString ();
		} else if (this.gameObject.tag == "money") {
			score.text = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<gamePlayScript> ().money.ToString ();
		} else if (this.gameObject.tag == "meals") {
			score.text = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<gamePlayScript> ().mealsAvailable.ToString ();
		} else if (this.gameObject.tag == "score") {
			score.text = "Level Score: " + GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<gamePlayScript> ().score.ToString ("F0");
	} else if (this.gameObject.tag == "time") 
		score.text = "Time Taken: " + GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<gamePlayScript> ().time.ToString ("F0");
	}

	// Code stub for testing interaction between objects and scripts.
	public void Test ()
	{
		Debug.Log ("Hello!");
	}
}

