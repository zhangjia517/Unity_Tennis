using UnityEngine;
using System.Collections;

public class PathCameraController : MonoBehaviour{
	public Transform target;
	
	void LateUpdate () {
		iTween.LookUpdate(gameObject,target.position,2);
	}
}

