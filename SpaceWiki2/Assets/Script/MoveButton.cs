using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour {
    bool IsMove =false;
    public float Step;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if(IsMove)
        {
            transform.Translate(0, Step, 0);
        }else 
        {
            transform.Translate(0, -Step, 0);
        }
        IsMove = !IsMove;
    }
}
