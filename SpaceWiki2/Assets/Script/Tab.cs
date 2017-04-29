using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tab : MonoBehaviour {

    public SpriteRenderer Menu;
    public GameObject Tabs;
    public GameObject MyTabs;

    public int ID;
    public Sprite sp;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        foreach (Transform child in Tabs.transform)
        {
            child.gameObject.SetActive(false);
        }
        Menu.sprite = sp;
        MyTabs.SetActive(true);
    }
}
