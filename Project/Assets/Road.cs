using UnityEngine;
using System.Collections;

public class Road : Obj
{

    public bool built = false;
    public Sprite[] pathTypes;

    public override void OnTouch()
    {
        base.OnTouch();
        Debug.Log("built!");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = pathTypes [1];
        built = true;
    }
}
