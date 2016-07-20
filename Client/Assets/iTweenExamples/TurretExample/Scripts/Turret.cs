using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour{
	public Rigidbody bullet;
	
	void Update(){
		//rotation:
		Vector3 mousePos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.transform.position.y);
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
		iTween.LookUpdate(gameObject,iTween.Hash("looktarget",worldPos,"time",2,"axis","y"));
		
		//fire:
		if(Input.GetMouseButtonDown(0)){
			Rigidbody clone = (Rigidbody)Instantiate(bullet,new Vector3(transform.position.x,1.5f,transform.position.z),transform.rotation);
			clone.velocity = transform.TransformDirection (Vector3.forward * 10);
		}
	}
}

