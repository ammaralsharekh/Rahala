using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderVR : MonoBehaviour {
    //public int x;
    public Texture[] textures;
    Material mat;
    public int Current = 0;
	// Use this for initialization
	void Start () {
        mat= GetComponent<Material>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Current++;
        if(Current == textures.Length)
        {
            Current = 0;
        }
        mat.mainTexture = textures[Current];
    }
}
