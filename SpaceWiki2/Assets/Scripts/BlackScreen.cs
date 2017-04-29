using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour {
	public float firstDuration = 1;

	bool isBlack = true;
	SpriteRenderer spriteRdr;
	// Use this for initialization
	void Start () {
		spriteRdr = transform.GetComponent<SpriteRenderer> ();
		spriteRdr.color = new Color (1,1,1,1);
		StartCoroutine (FadeIn(firstDuration));
	}
	
	// Update is called once per frame
	void Update () {
	}

	public IEnumerator FadeIn( float duration){
		while (spriteRdr.color.a >= 0){
			spriteRdr.color -= new Color(1,1,1,Time.deltaTime / duration);
			yield return null;
		}
		isBlack = false;
	}
	public IEnumerator FadeOut( float duration){
		while (spriteRdr.color.a <= 1){
			spriteRdr.color += new Color(1,1,1,Time.deltaTime / duration);
			yield return null;
		}
		isBlack = true;
	}

	public bool GetState(){
		return isBlack;
	}
}
