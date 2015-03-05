using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Raycaster : MonoBehaviour
{
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			if (GetComponent<gamePlayScript> ().buildingBuilt == true) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 100)) {
					hit.collider.GetComponent<Obj> ().OnTouch ();
					GetComponent<gamePlayScript> ().buildingBuilt = false;
				}
			}
		}
	}
}
