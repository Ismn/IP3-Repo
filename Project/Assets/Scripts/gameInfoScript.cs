using UnityEngine;
using System.Collections;

public class gameInfoScript : MonoBehaviour {

	public int previousMeals;
	public int previousMoney;
	public int previousAwareness;
	public int score;
	public float timeTaken;

	public GameObject referenceToOurGameScores;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		score = (previousAwareness * 2) + (previousMeals * 1.25) + previousMoney / timeTaken;
	}
}
