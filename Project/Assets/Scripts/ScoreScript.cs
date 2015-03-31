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
	void Update ()
	{
		if (this.gameObject.tag == "awareness") {
			score.text = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<gamePlayScript> ().awareness.ToString ();
		} else if (this.gameObject.tag == "money") {
			score.text = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<gamePlayScript> ().money.ToString ();
		} else if (this.gameObject.tag == "meals") 
			score.text = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<gamePlayScript> ().mealsAvailable.ToString ();
	}
}

