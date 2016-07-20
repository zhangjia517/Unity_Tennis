using UnityEngine;
using System.Collections;

public class InfiniteBackground : MonoBehaviour{
	public float scrollSpeed;
	Transform cam;
	Vector3 cameraInit;

	void Start (){
		cam=Camera.main.transform;
		cameraInit=new Vector3(cam.position.x,cam.position.y,cam.position.z);
	}

	void FixedUpdate (){
		Vector3 difference=cameraInit - cam.position;
		GetComponent<Renderer>().material.mainTextureOffset = difference*scrollSpeed;
	}
}