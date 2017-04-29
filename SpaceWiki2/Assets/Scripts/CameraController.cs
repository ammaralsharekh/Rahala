using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float speed = 50;
	public float dragSensivity = 2;
	public bool keyboardRot = true;
	public bool mouseRot = true;
	public bool dragRot = true;

	private float x = 0.0f;
	private float y = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//****Keyboard Controls****\\
		if(keyboardRot){
			x += Input.GetAxis("Horizontal") * speed*Time.deltaTime;
			y -= Input.GetAxis("Vertical") * speed*Time.deltaTime;
		}
#if !UNITY_ANDROID && !UNITY_IOS || UNITY_EDITOR
		//****Mouse Controls****\\
		if(mouseRot && Input.GetMouseButton(0)){
			x += Input.GetAxis("Mouse X") * speed*Time.deltaTime * dragSensivity;
			y -= Input.GetAxis("Mouse Y")*1.5f * speed*Time.deltaTime * dragSensivity;
		}
#endif
		//****Touch Controls****\\
		if(dragRot && Input.touchCount == 1){
			Touch f0 = Input.GetTouch(0);
			Vector3 f0Delta2 = new Vector3(f0.deltaPosition.x, -f0.deltaPosition.y, 0);
			x+= Mathf.Deg2Rad*f0Delta2.x* dragSensivity*10;
			y+= Mathf.Deg2Rad*f0Delta2.y* dragSensivity*10;	
		}

		y = ClampAngle(y, -85, 85);
		Quaternion rotation = Quaternion.Euler(y, x, 0.0f);		
		transform.rotation = rotation;
	}
//	void OnGUI(){
//		GUI.Box(new Rect(0,0, 128,64),"");
//		GUILayout.Label("X = : " + x);
//		GUILayout.Label("Y = " + y);
//	}
	public static float ClampAngle (float angle, float min, float max) {
		if (angle < -360.0f)
			angle += 360.0f;
		if (angle > 360.0f)
			angle -= 360.0f;
		return Mathf.Clamp (angle, min, max);
	}
}
