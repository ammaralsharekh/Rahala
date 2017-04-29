using UnityEngine;
using System.Collections;

public class FollowCamRotation : MonoBehaviour {
	public GameObject cam;
	public float speed = 0.5f;

	private Vector3 v3Offset;
	// Use this for initialization
	void Start () {
		v3Offset = transform.position - cam.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = cam.transform.position + v3Offset;
		transform.rotation  = Quaternion.Slerp (transform.rotation, cam.transform.rotation, speed * Time.deltaTime);
	}
}
