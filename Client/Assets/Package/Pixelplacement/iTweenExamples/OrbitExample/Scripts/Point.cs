using UnityEngine;
public class Point : MonoBehaviour {
	void OnDrawGizmos(){
		Gizmos.DrawWireSphere(transform.position,.25f);	
	}
}
