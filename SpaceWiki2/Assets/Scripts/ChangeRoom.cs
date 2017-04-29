using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ChangeRoom : MonoBehaviour {
	public List<Texture2D> textureSphere;
    public string[] toolTip;
    public FadeOut text;
	public float fadeDuration = 1;

	bool inSight = false;
	bool isChanging = false;
	float count = 0;
	float countLerp = 0;
	Animator reticleAnimator; 
	BlackScreen blkScreen;
	GameObject sphereScreen;

	private Color color = new Color(0,0,0,0);
	private int i = 1;

	void Start() {
		reticleAnimator = GameObject.Find ("Reticle").GetComponentInChildren<Animator> ();
		blkScreen = GameObject.Find ("BlackScreen").GetComponent<BlackScreen>();
		sphereScreen = GameObject.Find ("sphere");
	}
	//**** Increase the circle size when you look at it ****\\
	public void IncreaseChildSize(){
		if(!isChanging){
			if (transform.GetChild (0).localScale.x <= 0.9f) {
				transform.GetChild (0).localScale += new Vector3 (.5f * Time.deltaTime, .5f * Time.deltaTime, .5f * Time.deltaTime);
				reticleAnimator.SetBool ("LookSomething", true);
			} else {
				StartCoroutine (FadeChangeRoom ());
				reticleAnimator.SetBool ("LookSomething", false);
			}
			count = 0.5f;
		}
	}
	//**** And decrease it when you're not looking at it ****\\
	void DecreaseChildSize(){
		reticleAnimator.SetBool ("LookSomething", false);
		if(transform.GetChild(0).localScale.x > 0)
			transform.GetChild(0).localScale -= new Vector3(2*Time.deltaTime,2*Time.deltaTime,2*Time.deltaTime);
	}

	void Update(){
		if (count>0){
			count -= Time.deltaTime;
			inSight = true;
		} else inSight = false;

		if(!inSight){
			DecreaseChildSize();
		}
	}
	IEnumerator FadeChangeRoom (){
		isChanging = true;
		transform.GetChild(0).localScale = new Vector3(0,0,0);
		StartCoroutine(blkScreen.FadeOut(fadeDuration));
		yield return new WaitForSeconds(fadeDuration+0.1f);
		sphereScreen.GetComponent<Renderer>().material.mainTexture = textureSphere[i];
        //Ammar Alsharekh
        text.text = toolTip[i];

        if (i == textureSphere.Count-1)
			i=0;
		else i++;
		isChanging = false;		
		StartCoroutine(blkScreen.FadeIn(fadeDuration));
		yield return null;
	}

//	void OnGUI(){
//		if (!CardboardOnGUI.OKToDraw(this)) {
//			return;
//		}
//		//color.a = 1;
//		GUI.color = color;
//		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), texWhite);
//
//	}
}
