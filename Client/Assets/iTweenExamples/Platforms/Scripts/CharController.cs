using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
	bool grounded = false;
	public float jumpForce=900;
	public float moveSpeed=20;
	
	void Start(){
		//setup feel:
		Physics.gravity=new Vector3(0,-60,0);
		GetComponent<Rigidbody>().angularDrag=7;
	}
	
	void Update(){
		if(Input.GetKeyDown("right") || Input.GetKeyDown("left")){
			GetComponent<Rigidbody>().angularVelocity=Vector3.zero;	
		}
		
		if(grounded){
			if(Input.GetKey("right")){
				GetComponent<Rigidbody>().AddForce(new Vector3(moveSpeed*Time.deltaTime,0,0));	
			}
			if(Input.GetKey("left")){
				GetComponent<Rigidbody>().AddForce(new Vector3(-moveSpeed*Time.deltaTime,0,0));	
			}
			if(Input.GetKeyDown("space") ){
				GetComponent<Rigidbody>().AddForce(new Vector3(0,jumpForce,0));	
			}
		}
		
		//lock the z position for 2D:
		Vector3 tempPos = transform.position;
		tempPos.z=0;
		transform.position=tempPos;
	}
	
	void OnCollisionStay(Collision collisionInfo){
		if(collisionInfo.gameObject.name == "Ground"){
			grounded=true;
		}
	}
	
	void OnCollisionEnter(Collision collisionInfo){
		if(collisionInfo.gameObject.name == "Ground"){
			grounded=true;
			transform.parent=collisionInfo.transform;
		}
	}
	
	void OnCollisionExit(Collision collisionInfo){
		if(collisionInfo.gameObject.name == "Ground"){
			transform.parent=null;
			grounded=false;
		}
	}
}
