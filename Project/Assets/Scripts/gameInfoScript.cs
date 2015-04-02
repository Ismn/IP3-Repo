using UnityEngine;
using System.Collections;

public class gameInfoScript : MonoBehaviour {

	public float previousMeals;
	public float previousMoney;
	public float previousAwareness;
	public float score;
	public float timeTaken;

	public GameObject referenceToOurGameScores;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		score = (previousAwareness * 2) + (previousMeals * 1.25f) + previousMoney / timeTaken;

	}
}
