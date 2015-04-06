/* ******************
 * Ross McIntyre, 
 * IP3 Team 4,
 * 2015
 * ******************
 * Framerate code adapted from wiki post here:
 * http://wiki.unity3d.com/wiki/index.php?title=FramesPerSecond
 * Script : JavaScript - FramesPerSecond.js
 * Created by Aras Pranckevicius, user "NeARAZ"
 * ******************
 * Adapted for this project from Java to C#
 * ******************
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FramerateDebugger : MonoBehaviour 
{
	// Declare objects to interact with.
	Text frameRate;

	// ... And variables
	float updateInterval = 0.5f;
	private float accum = 0.0f;
	private int frames = 0;
	private float timeleft;


	// Use this for initialization
	void Start () 
	{    
		frameRate = GetComponent <Text>();
		timeleft = updateInterval;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeleft -= Time.deltaTime;
		accum += Time.timeScale / Time.deltaTime;
		++frames;

		if (timeleft <= 0.0f)
		{
			frameRate.text = "" + (accum / frames).ToString("f2");
			timeleft = updateInterval;
			accum = 0.0f;
			frames = 0;
		}
	}
}
