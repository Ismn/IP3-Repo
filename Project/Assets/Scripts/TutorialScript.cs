using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{

	public GameObject magnus;
	public GameObject fergus;
	public GameObject textbox;
	public Text messageToPlayer;
	public Text messageToPlayer2;
	public Component messages;



	// Use this for initialization
	void Start ()
	{

		messageToPlayer = GetComponent<Text> ();
		BeginTutorial ();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	public void BeginTutorial ()
	{
		if (Application.loadedLevelName == "MAINSCENEFINAL") {
			Debug.Log ("Tutorial Begun");
			magnus.SetActive (true);
			messageToPlayer.text = "Hi there! Welcome to Bosnia! My name is Magnus MacFarlane-Barrow, and I'm ready to deliver some of these amazing food supplies to the kids in Bosnia! Luckily, I've got some help from you and my brother Fergus!".ToString ();
			
			StartCoroutine (secondPartTutorialWait ());
		}
	}
	IEnumerator secondPartTutorialWait ()
	{
		yield return new WaitForSeconds (6.0f);
		secondPartTutorial ();
	}
	public void secondPartTutorial ()
	{
		magnus.SetActive (false);
		fergus.SetActive (true);
		messageToPlayer.text = "Hi I'm Fergus! For some reason I'm grumpier than the other version of me! We're really glad to have you working with us!";
		StartCoroutine (thirdPartTutorialWait ());
	}
	IEnumerator thirdPartTutorialWait ()
	{
		yield return new WaitForSeconds (6.0f);
		thirdPartTutorial ();
	}
	public void thirdPartTutorial ()
	{
		magnus.SetActive (true);
		fergus.SetActive (false);
		messageToPlayer.text = "Too right! Okay first of all, let's go over the basics! Use WASD to move your camera all over the scene! Go Up, Down, Left, Right!";
		StartCoroutine (fourthPartTutorialWait ());
	}
	IEnumerator fourthPartTutorialWait ()
	{
		yield return new WaitForSeconds (4.0f);
		fourthPartTutorial ();
	}
	public void fourthPartTutorial ()
	{

		magnus.SetActive (false);
		fergus.SetActive (true);
		messageToPlayer.text = "Well done! That helps us see the area around us! Next we'll need to learn how to move our trucks to those needy kids all over Bosnia!";
	}
}
