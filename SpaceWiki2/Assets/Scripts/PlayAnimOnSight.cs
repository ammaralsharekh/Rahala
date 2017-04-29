using UnityEngine;
using System.Collections;

public class PlayAnimOnSight : MonoBehaviour {
	Animator animator; 
	Animator reticleAnimator; 
	bool isOnSight = false;
	float timer = 0;

	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator> ();
		reticleAnimator = GameObject.Find ("Reticle").GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		timer += Time.deltaTime;
		if (isOnSight) {
			animator.SetBool ("OnSight", true);
			reticleAnimator.SetBool ("LookSomething", true);
		} else {
			animator.SetBool ("OnSight", false);
			reticleAnimator.SetBool ("LookSomething", false);
		}
		//**** If you don't watch the object during 1 seconde ****\\
		if (timer >= 1)
			isOnSight = false;
	
	}

	public void OnSightEnter (){
		isOnSight = true;
		timer = 0;
	}
	public void OnSightExit (){
		isOnSight = false;
	}

	public IEnumerator Disable (){
		isOnSight = false;
		yield return new WaitForSeconds (1f);
		gameObject.SetActive (false);
	}
}
