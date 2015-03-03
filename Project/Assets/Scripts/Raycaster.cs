using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Raycaster : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<Obj>())
                {
                    hit.collider.GetComponent<Obj>().OnTouch();
                }
            }
        }
    }
}
