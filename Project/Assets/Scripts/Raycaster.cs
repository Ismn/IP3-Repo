using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//this script detects when the mouse has been clicked/ screen touched and if
//able to build, allows a building to be built

public class Raycaster : MonoBehaviour
{
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			if (GetComponent<gamePlayScript> ().canBuild == true) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 100)) {
					hit.collider.GetComponent<Obj> ().OnTouch ();
					GetComponent<gamePlayScript> ().canBuild = false;
					GetComponent<gamePlayScript> ().buildingBuilt = true;
				}
			}
		}
	}
}
