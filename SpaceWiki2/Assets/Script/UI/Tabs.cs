using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Tabs : MonoBehaviour {

    public GameObject VRObjects;
    public GameObject ArticleObjects;
    // Use this for initialization
    void Start () {
      //  VRSettings.LoadDeviceByName("");
       // VRSettings.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnableVR(bool Enable)
    {
        //VRSettings.enabled = enabled;

        //VRObjects.SetActive(Enable);
        //ArticleObjects.SetActive(!Enable);
    }
}
