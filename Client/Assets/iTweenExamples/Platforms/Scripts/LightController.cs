using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour{
	public Transform target;
	
	void FixedUpdate (){
		transform.position=new Vector3(target.position.x,target.position.y+2.5f,target.position.z-1.6f);
	}
}

