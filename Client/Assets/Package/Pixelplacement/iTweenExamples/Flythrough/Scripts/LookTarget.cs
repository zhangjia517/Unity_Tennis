using UnityEngine;
public class LookTarget : MonoBehaviour {
	void OnDrawGizmos(){
		Gizmos.color=Color.cyan;
		Gizmos.DrawSphere(transform.position,.25f);	
	}
}
