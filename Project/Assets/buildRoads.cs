using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class buildRoads : MonoBehaviour {

	public List<Sprite> pathtypes;
	bool built = false;
	

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null)
			{
				if(hit.transform.gameObject.tag == "path" && built == false)
				{
				Debug.Log ("built!");
				this.gameObject.GetComponent<SpriteRenderer>().sprite = pathtypes[1];
				built = true;
				
				}
			}
		}
	}
}
