using UnityEngine;
using System.Collections;

public class PlayMovieTexture : MonoBehaviour {
#if !UNITY_ANDROID && !UNITY_IOS
	public MovieTexture movie;
	public bool audio = false;
	// Use this for initialization
	void Start () {

		GetComponent<MeshRenderer>().material.mainTexture = movie as MovieTexture;
		//If you want your video to loop
		movie.loop = true;		
		movie.Play ();

		//If you want to add audio attach an Audio Source Component to the sphere
		if(audio){
			GetComponent<AudioSource>().clip = movie.audioClip;
			GetComponent<AudioSource>().Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
#endif
}
